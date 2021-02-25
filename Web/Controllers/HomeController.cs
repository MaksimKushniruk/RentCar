using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.DTO;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // TODO: logger, error page without caching 
        private readonly ICarService carService;
        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CarDto> carDtos = await carService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
            }).CreateMapper();
            return View(mapper.Map<IEnumerable<CarDto>, IEnumerable<CarViewModel>>(carDtos));
        }
    }
}