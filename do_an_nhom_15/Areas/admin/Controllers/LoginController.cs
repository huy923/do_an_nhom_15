using Microsoft.AspNetCore.Mvc;

namespace do_an_nhom_15.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(model: null);
        }
    }
}
