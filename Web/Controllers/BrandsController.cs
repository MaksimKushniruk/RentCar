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
    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        // TODO: Use Automapper
        public IActionResult Index()
        {
            IEnumerable<BrandDto> brandDtos = brandService.GetAll();
            List<BrandViewModel> brandViewModels = new List<BrandViewModel>();
            foreach (var brandDto in brandDtos)
            {
                brandViewModels.Add(new BrandViewModel
                {
                    Id = brandDto.Id,
                    Title = brandDto.Title
                });
            }
            return View(brandViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BrandDto brandDto = new BrandDto { Title = model.Title };
                    brandService.Create(brandDto);
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
                    BrandDto brandDto = brandService.Get(id);
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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    BrandDto brandDto = brandService.Get(id);
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
        public IActionResult Edit(BrandViewModel model)
        {
            try
            {
                brandService.Edit(new BrandDto { Id = model.Id, Title = model.Title });
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
                    BrandDto brandDto = brandService.Get(id);
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
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    brandService.Delete(id);
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
            brandService.Dispoce();
            base.Dispose(disposing);
        }
    }
}
