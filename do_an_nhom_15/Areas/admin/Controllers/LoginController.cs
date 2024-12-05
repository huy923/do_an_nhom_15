using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;

namespace do_an_nhom_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            var checkUser = _context.AdminUsers.Where(u => (u.Username == username) && (u.Password == password)).FirstOrDefault();
            if (checkUser != null)
            {

                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1) 
                };
                Response.Cookies.Append("AdminLoggedIn", "true", cookieOptions);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            ViewBag.ErrorMessage = "User or password is wrong!";
            return View("Index");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("AdminLoggedIn");
            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
    }
}
