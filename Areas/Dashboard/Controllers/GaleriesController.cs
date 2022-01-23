using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Entities.Shop;
using ECommerce.Controllers;

namespace ECommerce.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class GaleriesController : BaseController
    {
        private readonly ShopContext _context;

        public GaleriesController(ShopContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Galeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galery.ToListAsync());
        }

        // GET: Dashboard/Galeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galery = await _context.Galery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galery == null)
            {
                return NotFound();
            }

            return View(galery);
        }

        // GET: Dashboard/Galeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Galeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Active,Deleted,CreateDate")] Galery galery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galery);
        }

        // GET: Dashboard/Galeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galery = await _context.Galery.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }
            return View(galery);
        }

        // POST: Dashboard/Galeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Active,Deleted,CreateDate")] Galery galery)
        {
            if (id != galery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaleryExists(galery.Id))
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
            return View(galery);
        }

        // GET: Dashboard/Galeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galery = await _context.Galery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galery == null)
            {
                return NotFound();
            }

            return View(galery);
        }

        // POST: Dashboard/Galeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galery = await _context.Galery.FindAsync(id);
            _context.Galery.Remove(galery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaleryExists(int id)
        {
            return _context.Galery.Any(e => e.Id == id);
        }
    }
}
