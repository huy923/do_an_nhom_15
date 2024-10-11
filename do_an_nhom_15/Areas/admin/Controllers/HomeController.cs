using Microsoft.AspNetCore.Mvc;

namespace do_an_nhom_15.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult Button()
        { 
            return View(); 
        }
    }
}
