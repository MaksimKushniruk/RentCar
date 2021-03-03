using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.DTO;
using Web.Models;
using Microsoft.AspNetCore.Http;
using Core.Validation;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // переменная юзернейм, которая будет использоваться как идентификатор корзины в бд
        private string _username = null;



        // TODO: logger, error page without caching 
        private readonly ICarService carService;
        private readonly ICartService cartService;
        public HomeController(ICarService carService, ICartService cartService)
        {
            this.carService = carService;
            this.cartService = cartService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CarDto> carDtos = await carService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
            }).CreateMapper();

            // "cart" to Constante
            if (Request.Cookies.ContainsKey("cart"))
            {
                _username = Request.Cookies["cart"];
            }
            if (_username == null)
            {
                _username = Guid.NewGuid().ToString();
                var options = new CookieOptions { IsEssential = true, Expires = DateTime.Today.AddDays(10) };
                Response.Cookies.Append("cart", _username, options);
            }

            try
            {
                CartDto cartDto = await cartService.GetAsync(_username);
            }
            catch (RentCarValidationException ex)
            {
                await cartService.CreateAsync(new CartDto { Username = _username });
            }




            // продолжение метода
            return View(mapper.Map<IEnumerable<CarDto>, IEnumerable<CarViewModel>>(carDtos));
        }
    }
}