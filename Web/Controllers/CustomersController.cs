using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
