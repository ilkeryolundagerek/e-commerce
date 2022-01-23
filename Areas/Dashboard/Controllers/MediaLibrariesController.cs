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
    public class MediaLibrariesController : BaseController
    {
        private readonly ShopContext _context;

        public MediaLibrariesController(ShopContext context)
        {
            _context = context;
        }

        // GET: Dashboard/MediaLibraries
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.MediaLibrary.Include(m => m.Galery);
            return View(await shopContext.ToListAsync());
        }

        // GET: Dashboard/MediaLibraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaLibrary = await _context.MediaLibrary
                .Include(m => m.Galery)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaLibrary == null)
            {
                return NotFound();
            }

            return View(mediaLibrary);
        }

        // GET: Dashboard/MediaLibraries/Create
        public IActionResult Create()
        {
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id");
            return View();
        }

        // POST: Dashboard/MediaLibraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,GaleryId,Id,Title,Description,Active,Deleted,CreateDate")] MediaLibrary mediaLibrary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaLibrary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id", mediaLibrary.GaleryId);
            return View(mediaLibrary);
        }

        // GET: Dashboard/MediaLibraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaLibrary = await _context.MediaLibrary.FindAsync(id);
            if (mediaLibrary == null)
            {
                return NotFound();
            }
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id", mediaLibrary.GaleryId);
            return View(mediaLibrary);
        }

        // POST: Dashboard/MediaLibraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,GaleryId,Id,Title,Description,Active,Deleted,CreateDate")] MediaLibrary mediaLibrary)
        {
            if (id != mediaLibrary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaLibrary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaLibraryExists(mediaLibrary.Id))
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
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id", mediaLibrary.GaleryId);
            return View(mediaLibrary);
        }

        // GET: Dashboard/MediaLibraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaLibrary = await _context.MediaLibrary
                .Include(m => m.Galery)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaLibrary == null)
            {
                return NotFound();
            }

            return View(mediaLibrary);
        }

        // POST: Dashboard/MediaLibraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaLibrary = await _context.MediaLibrary.FindAsync(id);
            _context.MediaLibrary.Remove(mediaLibrary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaLibraryExists(int id)
        {
            return _context.MediaLibrary.Any(e => e.Id == id);
        }
    }
}
