using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace do_an_nhom_15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Product_single(){return View();}
        public IActionResult Services(){return View();}
        public IActionResult Blog(){return View();}
        public IActionResult About(){return View();}
        public IActionResult Cart(){return View();}
        public IActionResult Checkout(){return View();}
        public IActionResult Contact(){return View();}
        public IActionResult Blog_single(){return View("Blog_single");}
        public IActionResult Shop(){return View("Blog_single");}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
