using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]//Kendi eklemez, sizin eklemeniz gerekli.
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
