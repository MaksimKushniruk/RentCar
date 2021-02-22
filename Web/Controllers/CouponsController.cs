using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Web.Models;
using Core.Validation;

namespace Web.Controllers
{
    public class CouponsController : Controller
    {
        private readonly ICouponService couponService;
        public CouponsController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CouponDto> couponDtos = await couponService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CouponDto, CouponViewModel>())
                    .CreateMapper();
            return View(mapper.Map<IEnumerable<CouponDto>, IEnumerable<CouponViewModel>>(couponDtos));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapper = new MapperConfiguration(cfg =>
                        cfg.CreateMap<CouponViewModel, CouponDto>())
                            .CreateMapper();
                    await couponService.CreateAsync(mapper.Map<CouponViewModel, CouponDto>(model));
                    return RedirectToAction("Index");
                }
                catch (RentCarValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    CouponDto couponDto = await couponService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg =>
                        cfg.CreateMap<CouponDto, CouponViewModel>())
                            .CreateMapper();
                    if (couponDto != null)
                    {
                        return View(mapper.Map<CouponDto, CouponViewModel>(couponDto));
                    }
                }
                catch
                {
                    // empty
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    CouponDto couponDto = await couponService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg =>
                        cfg.CreateMap<CouponDto, CouponViewModel>())
                            .CreateMapper();
                    if (couponDto != null)
                    {
                        return View(mapper.Map<CouponDto, CouponViewModel>(couponDto));
                    }
                }
                catch
                {
                    // empty
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CouponViewModel model)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                    cfg.CreateMap<CouponViewModel, CouponDto>())
                        .CreateMapper();
                await couponService.EditAsync(mapper.Map<CouponViewModel, CouponDto>(model));
                return RedirectToAction("Index");
            }
            catch (RentCarValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                try
                {
                    CouponDto couponDto = await couponService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg =>
                        cfg.CreateMap<CouponDto, CouponViewModel>())
                            .CreateMapper();
                    if (couponDto != null)
                    {
                        return View(mapper.Map<CouponDto, CouponViewModel>(couponDto));
                    }
                }
                catch
                {
                    // empty
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    await couponService.DeleteAsync(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    // empty
                }
            }
            return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            couponService.Dispose();
            base.Dispose(disposing);
        }
    }
}
