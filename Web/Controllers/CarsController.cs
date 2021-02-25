using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IBrandService brandService;
        private readonly IWebHostEnvironment app;
        public CarsController(ICarService carService, IBrandService brandService, IWebHostEnvironment appEnvironment)
        {
            app = appEnvironment;
            this.carService = carService;
            this.brandService = brandService;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<BrandDto> brandDtos = await brandService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDto, BrandViewModel>()
                    .ForMember(dst => dst.Cars, opt => opt.Ignore());
            }).CreateMapper();
            // TODO: create "CreateCarViewModel", add field - List<BrandViewModel> Brands and replace ViewBag 
            ViewBag.Brands = new SelectList(mapper.Map<IEnumerable<BrandDto>, IEnumerable<BrandViewModel>>(brandDtos), "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    string path = "/img/" + model.ModelName + ".jpg";
                    int i = 0;
                    while(new FileInfo(app.WebRootPath + path).Exists)
                    {
                        i++;
                        path = "/img/" + model.ModelName + i + ".jpg";
                    }

                    using (FileStream fs = new FileStream(app.WebRootPath + path, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fs);
                    }
                    model.ImagePath = path;
                }
                try
                {
                    var mapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BrandViewModel, BrandDto>();
                        cfg.CreateMap<CarViewModel, CarDto>();
                    }).CreateMapper();
                    await carService.CreateAsync(mapper.Map<CarViewModel, CarDto>(model));
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
                    CarDto carDto = await carService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BrandDto, BrandViewModel>();
                        cfg.CreateMap<CarDto, CarViewModel>();
                    }).CreateMapper();
                    if (carDto != null)
                    {
                        return View(mapper.Map<CarDto, CarViewModel>(carDto));
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
                    IEnumerable<BrandDto> brandDtos = await brandService.GetAllAsync();
                    var brandMapper = new MapperConfiguration(cfg => 
                        cfg.CreateMap<BrandDto, BrandViewModel>())
                            .CreateMapper();
                    // TODO: create "CreateCarViewModel", add field - List<BrandViewModel> Brands and replace ViewBag 
                    ViewBag.Brands = new SelectList(brandMapper.Map<IEnumerable<BrandDto>, IEnumerable<BrandViewModel>>(brandDtos), "Id", "Title");

                    CarDto carDto = await carService.GetAsync(id);
                    var carMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BrandDto, BrandViewModel>();
                        cfg.CreateMap<CarDto, CarViewModel>();
                    }).CreateMapper();
                    if (carDto != null)
                    {
                        return View(carMapper.Map<CarDto, CarViewModel>(carDto));
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
        public async Task<IActionResult> Edit(CarViewModel model)
        {
            try
            {
                if (model.Image != null)
                {
                    string path = "/img/" + model.ModelName + ".jpg";
                    int i = 0;
                    while (new FileInfo(app.WebRootPath + path).Exists)
                    {
                        i++;
                        path = "/img/" + model.ModelName + i + ".jpg";
                    }

                    using (FileStream fs = new FileStream(app.WebRootPath + path, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fs);
                    }
                    model.ImagePath = path;
                }

                IEnumerable<BrandDto> brandDtos = await brandService.GetAllAsync();
                var brandMapper = new MapperConfiguration(cfg =>
                    cfg.CreateMap<BrandDto, BrandViewModel>())
                        .CreateMapper();
                // TODO: create "CreateCarViewModel", add field - List<BrandViewModel> Brands and replace ViewBag 
                ViewBag.Brands = new SelectList(brandMapper.Map<IEnumerable<BrandDto>, IEnumerable<BrandViewModel>>(brandDtos), "Id", "Title");

                var carMapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BrandViewModel, BrandDto>();
                    cfg.CreateMap<CarViewModel, CarDto>();
                }).CreateMapper();
                await carService.EditAsync(carMapper.Map<CarViewModel, CarDto>(model));
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
                    CarDto carDto = await carService.GetAsync(id);
                    var carMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BrandDto, BrandViewModel>();
                        cfg.CreateMap<CarDto, CarViewModel>();
                    }).CreateMapper();
                    if (carDto != null)
                    {
                        return View(carMapper.Map<CarDto, CarViewModel>(carDto));
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
                    CarDto carDto = await carService.GetAsync(id);
                    FileInfo image = new FileInfo(app.WebRootPath + carDto.ImagePath);
                    if (image.Exists)
                    {
                        image.Delete();
                    }
                    await carService.DeleteAsync(id);
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
            carService.Dispoce();
            base.Dispose(disposing);
        }
    }
}
