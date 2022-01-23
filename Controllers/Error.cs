using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class Error : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page401()
        {
            return View();
        }
    }
}
