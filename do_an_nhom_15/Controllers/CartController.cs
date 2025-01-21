using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Controllers
{
    public class CartController(ILogger<HomeController> logger, CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;
        private readonly ILogger<HomeController> _logger = logger;
        public IActionResult Index()
        {
            ViewModel view = new()
            {
                CartList = [.. _context.Carts.Include(c => c.Product)],
                ProductList = [.. _context.Products]
            };
            return View(view);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
        //    return View();
        //}

        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Carts.Add(cart);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
        [HttpPost]
        public IActionResult Edit(int id, int Quantity)
        {
            var cart = _context.Carts.Find(id);
            if (cart != null)
            {
                if (Quantity < 1 || Quantity > 100)
                {
                    ModelState.AddModelError("Quantity", "Quantity must be between 1 and 100.");
                    return RedirectToAction("Index");
                }

                cart.Quantity = Quantity;
                _context.Carts.Update(cart);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
