using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using ECommerce.Controllers;

namespace ECommerce.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class RolesController : Controller
    {
        private readonly RoleManager<ShopRole> _roleManager;

        public RolesController(RoleManager<ShopRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: Dashboard/Roles
        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        // GET: Dashboard/Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopRole = await _roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopRole == null)
            {
                return NotFound();
            }

            return View(shopRole);
        }

        // GET: Dashboard/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Detail,Id,Name,NormalizedName,ConcurrencyStamp")] ShopRole shopRole)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(shopRole);
                return RedirectToAction(nameof(Index));
            }
            return View(shopRole);
        }

        // GET: Dashboard/Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopRole = await _roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopRole == null)
            {
                return NotFound();
            }
            return View(shopRole);
        }

        // POST: Dashboard/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Detail,Id,Name,NormalizedName,ConcurrencyStamp")] ShopRole shopRole)
        {
            if (id != shopRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _roleManager.UpdateAsync(shopRole);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopRoleExists(shopRole.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shopRole);
        }

        // GET: Dashboard/Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopRole = await _roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopRole == null)
            {
                return NotFound();
            }

            return View(shopRole);
        }

        // POST: Dashboard/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shopRole = await _roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            await _roleManager.DeleteAsync(shopRole);
            return RedirectToAction(nameof(Index));
        }

        private bool ShopRoleExists(string id)
        {
            return _roleManager.Roles.Any(e => e.Id == id);
        }
    }
}
