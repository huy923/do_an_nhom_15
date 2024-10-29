using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace do_an_nhom_15.Controllers
{
    public class HomeController(ILogger<HomeController> logger,CoffeeShopDbContext context)  : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly CoffeeShopDbContext _context = context;


        public IActionResult Index()
        {
            ViewModel product = new()
            {
                ProductList = [.. _context.Products]
            };
			      return View(product);
        }

        public IActionResult Menu(){return View();}
        public IActionResult Product_single(){return View();}
        public IActionResult Services(){return View();}
        public IActionResult Blog(){return View();}
        public IActionResult About(){return View();}
        public IActionResult Cart(){return View();}
        public IActionResult Checkout(){return View();}
        public IActionResult Contact(){return View();}
        public IActionResult Blog_single(){return View();}
        public IActionResult Shop(){return View();}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });}
    }
}
