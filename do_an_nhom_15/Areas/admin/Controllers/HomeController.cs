using Microsoft.AspNetCore.Mvc;

namespace do_an_nhom_15.Areas.admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Button()
        {
            return View();
        }
        public IActionResult Typography(){return View();}
        public IActionResult Widget() { return View();}
        public IActionResult Table() { return View(); }
        public IActionResult Signup() { return View(); }
        public IActionResult Signin() { return View(); }
        public IActionResult Form() { return View(); }
        public IActionResult Element() { return View(); }
        public IActionResult Chart() { return View(); }
        public IActionResult Blank() { return View(); }
        public IActionResult _404() { return View(); }
    }
}
