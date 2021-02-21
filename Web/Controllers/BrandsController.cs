using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using AutoMapper;

namespace Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BrandDto> brandDtos = await brandService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarDto, CarViewModel>();
                cfg.CreateMap<BrandDto, BrandViewModel>()
                    .ForMember(dst => dst.Cars, opt => opt.MapFrom(src => src.Cars));
            }).CreateMapper();
            return View(mapper.Map<IEnumerable<BrandDto>, IEnumerable<BrandViewModel>>(brandDtos));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await brandService.CreateAsync(new BrandDto { Title = model.Title });
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
                    BrandDto brandDto = await brandService.GetAsync(id);
                    if (brandDto != null)
                    {
                        return View(new BrandViewModel { Id = brandDto.Id, Title = brandDto.Title });
                    }
                }
                catch
                {
                    // TODO: Exception page
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
                    BrandDto brandDto = await brandService.GetAsync(id);
                    if (brandDto != null)
                    {
                        return View(new BrandViewModel { Id = brandDto.Id, Title = brandDto.Title });
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
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
            try
            {
                await brandService.EditAsync(new BrandDto { Id = model.Id, Title = model.Title });
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
                    BrandDto brandDto = await brandService.GetAsync(id);
                    if (brandDto != null)
                    {
                        return View(new BrandViewModel { Id = brandDto.Id, Title = brandDto.Title });
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
                    await brandService.DeleteAsync(id);
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
            brandService.Dispose();
            base.Dispose(disposing);
        }
    }
}
