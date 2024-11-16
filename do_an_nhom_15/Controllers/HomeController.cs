using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace do_an_nhom_15.Controllers
{
    public class HomeController(ILogger<HomeController> logger, CoffeeShopDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly CoffeeShopDbContext _context = context;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            ViewModel menu = new()
            {
                ProductList = [.. _context.Products]
            };
            return View(menu);
        }
        [HttpGet]
        public IActionResult Product_single(int id)
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(e => e.ProductId == id);
            ViewModel view = new()
            {
                ProductList = [.. _context.Products],
                SelectedProduct = product
            };
            return View(view);
        }
        public IActionResult Services() { return View(); }
        public IActionResult Blog() { return View(); }
        public IActionResult About() { return View(); }
        public IActionResult Cart()
        {
            ViewModel view = new()
            {
                CartList = [.. _context.Carts.Include(c => c.Product)],
                ProductList = [.. _context.Products]
            };
            return View(view);
        }
        [HttpPost]
        public IActionResult Cart(int id)
        {
            var remove = _context.Carts.Find(id);
            if (remove == null)
            {
                return NotFound();
            }
            _context.Carts.Remove(remove);
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }
        public IActionResult Checkout() { return View(); }
        public IActionResult Contact() { return View(); }

        public IActionResult Blog_single()

        {
            return View();
        }
        public IActionResult Shop() { return View(); }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() { return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
    }
}
