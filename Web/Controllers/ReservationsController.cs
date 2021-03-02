using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Web.Models;
using Core.Validation;
using Microsoft.AspNetCore.Http;

namespace Web.Controllers
{
    public class ReservationsController : Controller
    {
        private string _username = null;
        private readonly IReservationService reservationService;
        private readonly ICartService cartService;
        private readonly ICarService carService;
        private readonly ICustomerService customerService;
        private readonly ICouponService couponService;
        public ReservationsController(IReservationService reservationService, ICarService carService, ICustomerService customerService, ICouponService couponService, ICartService cartService)
        {
            this.couponService = couponService;
            this.customerService = customerService;
            this.carService = carService;
            this.reservationService = reservationService;
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ReservationDto> reservationDtos = await reservationService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, CustomerViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CouponDto, CouponViewModel>();
                cfg.CreateMap<ReservationDto, ReservationViewModel>();
            }).CreateMapper();
            return View(mapper.Map<IEnumerable<ReservationDto>, IEnumerable<ReservationViewModel>>(reservationDtos));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (Request.Cookies.ContainsKey("cart"))
            {
                _username = Request.Cookies["cart"];
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, CustomerViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CouponDto, CouponViewModel>();
                cfg.CreateMap<CartDto, CartViewModel>();
            }).CreateMapper();

            // TODO: use if...else mb

            try
            {
                return View(mapper.Map<CartDto, CartViewModel>(await cartService.GetAsync(_username)));
            }
            catch (RentCarValidationException ex)
            {
                CartDto cartDto = new CartDto { Username = _username };
                await cartService.CreateAsync(cartDto);
                return View(mapper.Map<CartDto, CartViewModel>(cartDto));
            }

        }

        [HttpGet]
        public async Task<IActionResult> SelectCar()
        {
            IEnumerable<CarDto> carDtos = await carService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
            }).CreateMapper();
            return View(mapper.Map<IEnumerable<CarDto>, IEnumerable<CarViewModel>>(carDtos));
        }

        [HttpPost]
        public async Task<IActionResult> SelectCar(int? id)
        {
            if (Request.Cookies.ContainsKey("cart"))
            {
                _username = Request.Cookies["cart"];
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, CustomerViewModel>();
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<CouponDto, CouponViewModel>();
                cfg.CreateMap<CartDto, CartViewModel>();
            }).CreateMapper();
            CartViewModel cartViewModel = mapper.Map<CartDto, CartViewModel>(await cartService.GetAsync(_username));
            if (id != null)
            {
                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BrandDto, BrandViewModel>();
                    cfg.CreateMap<CarDto, CarViewModel>();
                }).CreateMapper();
                CarViewModel carViewModel = mapper.Map<CarDto, CarViewModel>(await carService.GetAsync(id.Value));
                cartViewModel.Car = carViewModel;
            }

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerViewModel, CustomerDto>();
                cfg.CreateMap<BrandViewModel, BrandDto>();
                cfg.CreateMap<CarViewModel, CarDto>();
                cfg.CreateMap<CouponViewModel, CouponDto>();
                cfg.CreateMap<CartViewModel, CartDto>();
            }).CreateMapper();

            await cartService.EditAsync(mapper.Map<CartViewModel, CartDto>(cartViewModel));
            return RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> SelectCustomer()
        {
            IEnumerable<CustomerDto> customerDtos = await customerService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CustomerDto, CustomerViewModel>())
                    .CreateMapper();
            return View(mapper.Map<IEnumerable<CustomerDto>, IEnumerable<CustomerViewModel>>(customerDtos));
        }

        [HttpPost]
        public async Task<IActionResult> SelectCustomer(int? id)
        {
            if (Request.Cookies.ContainsKey("cart"))
            {
                _username = Request.Cookies["cart"];
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, CustomerViewModel>();
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<CouponDto, CouponViewModel>();
                cfg.CreateMap<CartDto, CartViewModel>();
            }).CreateMapper();
            CartViewModel cartViewModel = mapper.Map<CartDto, CartViewModel>(await cartService.GetAsync(_username));
            if (id != null)
            {
                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerDto, CustomerViewModel>();
                }).CreateMapper();
                CustomerViewModel customerViewModel = mapper.Map<CustomerDto, CustomerViewModel>(await customerService.GetAsync(id.Value));
                cartViewModel.Customer = customerViewModel;
            }

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerViewModel, CustomerDto>();
                cfg.CreateMap<BrandViewModel, BrandDto>();
                cfg.CreateMap<CarViewModel, CarDto>();
                cfg.CreateMap<CouponViewModel, CouponDto>();
                cfg.CreateMap<CartViewModel, CartDto>();
            }).CreateMapper();

            await cartService.EditAsync(mapper.Map<CartViewModel, CartDto>(cartViewModel));
            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> GetCoupon(string code)
        {
            if (Request.Cookies.ContainsKey("cart"))
            {
                _username = Request.Cookies["cart"];
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, CustomerViewModel>();
                cfg.CreateMap<BrandDto, BrandViewModel>();
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<CouponDto, CouponViewModel>();
                cfg.CreateMap<CartDto, CartViewModel>();
            }).CreateMapper();
            CartViewModel cartViewModel = mapper.Map<CartDto, CartViewModel>(await cartService.GetAsync(_username));
            if (!String.IsNullOrWhiteSpace(code))
            {
                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CouponDto, CouponViewModel>();
                }).CreateMapper();
                CouponViewModel couponViewModel = mapper.Map<CouponDto, CouponViewModel>(await couponService.GetByCodeAsync(code));
                cartViewModel.Coupon = couponViewModel;
            }

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerViewModel, CustomerDto>();
                cfg.CreateMap<BrandViewModel, BrandDto>();
                cfg.CreateMap<CarViewModel, CarDto>();
                cfg.CreateMap<CouponViewModel, CouponDto>();
                cfg.CreateMap<CartViewModel, CartDto>();
            }).CreateMapper();

            await cartService.EditAsync(mapper.Map<CartViewModel, CartDto>(cartViewModel));
            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CartViewModel, ReservationViewModel>();
                }).CreateMapper();

                ReservationViewModel reservation = mapper.Map<CartViewModel, ReservationViewModel>(model);

                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerViewModel, CustomerDto>();
                    cfg.CreateMap<BrandViewModel, BrandDto>();
                    cfg.CreateMap<CarViewModel, CarDto>();
                    cfg.CreateMap<CouponViewModel, CouponDto>();
                    cfg.CreateMap<ReservationViewModel, ReservationDto>();
                }).CreateMapper();

                ReservationDto reservationDto = mapper.Map<ReservationViewModel, ReservationDto>(reservation);
                reservationDto.Car = await carService.GetAsync(model.Car.Id);
                reservationDto.Customer = await customerService.GetAsync(model.Customer.Id);
                reservationDto.Coupon = await couponService.GetAsync(model.Coupon.Id);

                if (Request.Cookies.ContainsKey("cart"))
                {
                    await cartService.DeleteAsync(Request.Cookies["cart"]);
                }

                try
                {
                    await reservationService.CreateAsync(reservationDto);
                    return RedirectToAction("Index");
                }
                catch(RentCarValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View(model);
        }
    }
}
