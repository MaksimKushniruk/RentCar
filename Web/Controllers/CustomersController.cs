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

namespace Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CustomerDto> customerDtos = await customerService.GetAllAsync();
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<CustomerDto, CustomerViewModel>())
                    .CreateMapper();
            return View(mapper.Map<IEnumerable<CustomerDto>, IEnumerable<CustomerViewModel>>(customerDtos));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapper = new MapperConfiguration(cfg =>
                        cfg.CreateMap<CustomerViewModel, CustomerDto>())
                            .CreateMapper();
                    await customerService.CreateAsync(mapper.Map<CustomerViewModel, CustomerDto>(model));
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
                    CustomerDto customerDto = await customerService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg =>
                        cfg.CreateMap<CustomerDto, CustomerViewModel>())
                            .CreateMapper();
                    if (customerDto != null)
                    {
                        return View(mapper.Map<CustomerDto, CustomerViewModel>(customerDto));
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
                    CustomerDto customerDto = await customerService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg => 
                        cfg.CreateMap<CustomerDto, CustomerViewModel>())
                            .CreateMapper();
                    if(customerDto != null)
                    {
                        return View(mapper.Map<CustomerDto, CustomerViewModel>(customerDto));
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
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => 
                    cfg.CreateMap<CustomerViewModel, CustomerDto>())
                        .CreateMapper();
                await customerService.EditAsync(mapper.Map<CustomerViewModel, CustomerDto>(model));
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
                    CustomerDto customerDto = await customerService.GetAsync(id);
                    var mapper = new MapperConfiguration(cfg => 
                        cfg.CreateMap<CustomerDto, CustomerViewModel>())
                            .CreateMapper();
                    if (customerDto != null)
                    {
                        return View(mapper.Map<CustomerDto, CustomerViewModel>(customerDto));
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
                    await customerService.DeleteAsync(id);
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
            customerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
