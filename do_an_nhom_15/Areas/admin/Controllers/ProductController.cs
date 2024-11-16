using do_an_nhom_15.Models;
using elFinder.NetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace do_an_nhom_15.Areas.admin.Controllers
{
    [Area("Admin")]
    public class ProductController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;


        public IActionResult Index(string? searchTerm)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Name.Contains(searchTerm));
            }

            ViewModel model = new()
            {
                ProductList = [.. products]
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product product, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\datahome\images", formFile.FileName);

                    var directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath) && directoryPath != null)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    product.ImageUrl = "/datahome/images/" + formFile.FileName;
                    _context.Database.ExecuteSqlRaw(
                    "INSERT INTO Products (name, description, price, discount, stock, image_url, rating) " +
                    "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                    product.Name, product.Description, product.Price, product.Discount, product.Stock, product.ImageUrl, product.Rating);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(product);
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
