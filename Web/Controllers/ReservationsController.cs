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
        private readonly ICarService carService;
        private readonly ICustomerService customerService;
        private readonly ICouponService couponService;
        public ReservationsController(IReservationService reservationService, ICarService carService, ICustomerService customerService, ICouponService couponService)
        {
            this.couponService = couponService;
            this.customerService = customerService;
            this.carService = carService;
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
    }
}
