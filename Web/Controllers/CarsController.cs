using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult Index()
        {
            IEnumerable<CarDto> carDtos = carService.GetAll();
            List<CarViewModel> carViewModels = new List<CarViewModel>();
            foreach (CarDto carDto in carDtos)
            {
                carViewModels.Add(new CarViewModel
                {
                    Id = carDto.Id,
                    LicensePlate = carDto.LicensePlate,
                    ModelName = carDto.ModelName,
                    Color = carDto.Color,
                    Year = carDto.Year,
                    PricePerHour = carDto.PricePerHour,
                    Status = (CarStatus)carDto.Status,
                    BrandId = carDto.BrandId
                });
            }
            return View(carViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarDto carDto = new CarDto 
                    {
                        Id = model.Id,
                        LicensePlate = model.LicensePlate,
                        ModelName = model.ModelName,
                        Color = model.Color,
                        Year = model.Year,
                        PricePerHour = model.PricePerHour,
                        Status = (CarRentStatusDto)model.Status,
                        BrandId = model.BrandId
                    };
                    carService.Create(carDto);
                    return RedirectToAction("Index");
                }
                catch (RentCarValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    CarDto carDto = carService.Get(id);
                    if (carDto != null)
                    {
                        return View(new CarViewModel 
                        {
                            Id = carDto.Id,
                            LicensePlate = carDto.LicensePlate,
                            ModelName = carDto.ModelName,
                            Color = carDto.Color,
                            Year = carDto.Year,
                            PricePerHour = carDto.PricePerHour,
                            Status = (CarStatus)carDto.Status,
                            BrandId = carDto.BrandId
                        });
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
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    CarDto carDto = carService.Get(id);
                    if (carDto != null)
                    {
                        return View(new CarViewModel 
                        {
                            Id = carDto.Id,
                            LicensePlate = carDto.LicensePlate,
                            ModelName = carDto.ModelName,
                            Color = carDto.Color,
                            Year = carDto.Year,
                            PricePerHour = carDto.PricePerHour,
                            Status = (CarStatus)carDto.Status,
                            BrandId = carDto.BrandId
                        });
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
        public IActionResult Edit(CarViewModel model)
        {
            try
            {
                carService.Edit(new CarDto 
                {
                    Id = model.Id,
                    LicensePlate = model.LicensePlate,
                    ModelName = model.ModelName,
                    Color = model.Color,
                    Year = model.Year,
                    PricePerHour = model.PricePerHour,
                    Status = (CarRentStatusDto)model.Status,
                    BrandId = model.BrandId
                });
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
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                try
                {
                    CarDto carDto = carService.Get(id);
                    if (carDto != null)
                    {
                        return View(new CarViewModel 
                        {
                            Id = carDto.Id,
                            LicensePlate = carDto.LicensePlate,
                            ModelName = carDto.ModelName,
                            Color = carDto.Color,
                            Year = carDto.Year,
                            PricePerHour = carDto.PricePerHour,
                            Status = (CarStatus)carDto.Status,
                            BrandId = carDto.BrandId
                        });
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
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    carService.Delete(id);
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
