using Core.DTO;
using Core.Interfaces;
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
            foreach(var brandDto in brandDtos)
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
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
            return View(model);
        }
    }
}
