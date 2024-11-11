using Microsoft.AspNetCore.Mvc;
using do_an_nhom_15.Models;
namespace do_an_nhom_15.Areas
{
    [Area("Admin")]
    public class HomeController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;
        public IActionResult Index() { return View(); }
        public IActionResult Button() { return View(); }
        public IActionResult Typography() { return View(); }
        public IActionResult Widget() { return View(); }
        public IActionResult Table() { return View(); }
        public IActionResult Signup() { return View(model: null); }
        public IActionResult Form() { return View(); }
        public IActionResult Signin() { return View(model: null); }
        public IActionResult Element() { return View(); }
        public IActionResult Chart() { return View(); }
        public IActionResult Blank() { return View(); }
    }
}