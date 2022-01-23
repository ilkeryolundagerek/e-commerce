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
    public class ProductsController : BaseController
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
        }

        public ProductsController()
        {
        }

        // GET: Dashboard/Products
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Product.Include(p => p.Galery).Include(p => p.SubCategory);
            return View(await shopContext.ToListAsync());
        }

        // GET: Dashboard/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Galery)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Dashboard/Products/Create
        public IActionResult Create()
        {
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id");
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Id");
            return View();
        }

        // POST: Dashboard/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubCategoryId,Price,CampaingPrice,IsInCampaign,FeaturedImage,GaleryId,IsInStock,Id,Title,Description,Active,Deleted,CreateDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id", product.GaleryId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Id", product.SubCategoryId);
            return View(product);
        }

        // GET: Dashboard/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id", product.GaleryId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Id", product.SubCategoryId);
            return View(product);
        }

        // POST: Dashboard/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubCategoryId,Price,CampaingPrice,IsInCampaign,FeaturedImage,GaleryId,IsInStock,Id,Title,Description,Active,Deleted,CreateDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["GaleryId"] = new SelectList(_context.Galery, "Id", "Id", product.GaleryId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Id", product.SubCategoryId);
            return View(product);
        }

        // GET: Dashboard/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Galery)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Dashboard/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
