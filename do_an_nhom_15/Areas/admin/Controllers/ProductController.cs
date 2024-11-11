using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;

namespace do_an_nhom_15.Areas.admin.Controllers
{
    [Area("Admin")]
    public class ProductController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index()
        {
            ViewModel model = new()
            {
                ProductList = [.. _context.Products]
            };
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
