using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Entities.Identity;
using ECommerce.Controllers;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class UserRolesController : Controller
    {
        private readonly IdentityContext _context;
        private readonly RoleManager<ShopRole> _roleManager;
        private readonly UserManager<ShopUser> _userManager;
        public UserRolesController(IdentityContext context, RoleManager<ShopRole> roleManager, UserManager<ShopUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Dashboard/UserRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRoles.ToListAsync());
        }

        // GET: Dashboard/UserRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userRoles == null)
            {
                return NotFound();
            }

            return View(userRoles);
        }

        // GET: Dashboard/UserRoles/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.Users,"Id", "UserName");
            ViewBag.RoleId = new SelectList(_context.Roles, "Name", "Name");
            return View();
        }

        // POST: Dashboard/UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                ShopUser user = await _userManager.GetUserAsync(User);
                await _userManager.AddToRoleAsync(user, userRoles.RoleId);
                return RedirectToAction(nameof(Index));
            }
            return View(userRoles);
        }

        // GET: Dashboard/UserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles == null)
            {
                return NotFound();
            }
            return View(userRoles);
        }

        // POST: Dashboard/UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,RoleId")] UserRoles userRoles)
        {
            if (id != userRoles.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRolesExists(userRoles.UserId))
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
            return View(userRoles);
        }

        // GET: Dashboard/UserRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userRoles == null)
            {
                return NotFound();
            }

            return View(userRoles);
        }

        // POST: Dashboard/UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userRoles = await _context.UserRoles.FindAsync(id);
            _context.UserRoles.Remove(userRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRolesExists(string id)
        {
            return _context.UserRoles.Any(e => e.UserId == id);
        }
    }
}
