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
        
    }
}
