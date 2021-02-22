using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Web.Models;

namespace Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ReservationDto> reservationDtos = await reservationService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, CustomerViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<CouponDto, CouponViewModel>();
                cfg.CreateMap<ReservationDto, ReservationViewModel>();
            }).CreateMapper();
            return View(mapper.Map<IEnumerable<ReservationDto>, IEnumerable<ReservationViewModel>>(reservationDtos));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

        }
    }
}
