using ECommerce.Entities.Identity;
using ECommerce.Models;
using ECommerce.Workers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class Shop : BaseController
    {
        private readonly UserManager<ShopUser> userManager;

        public Shop(UserManager<ShopUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index(string term = null, int page = 1, int page_size = 9)
        {
            if (string.IsNullOrEmpty(term))
            {
                return View(new ShopIndexViewModel(page, page_size));
            }
            else
            {
                return View(new ShopIndexViewModel(term, page, page_size));
            }
        }

        public IActionResult Detail(int? id)
        {
            return View(new ShopDetailViewModel((int)id));
        }

        public IActionResult AddToCart(int pid)
        {
            string uid = userManager.GetUserId(User);
            CartWorker.AddToCart(pid, uid);
            return RedirectToAction("Index");
        }

        public IActionResult CartDetail()
        {
            string uid = userManager.GetUserId(User);
            return View(new CartDetailViewModel(uid));
        }
    }
}
