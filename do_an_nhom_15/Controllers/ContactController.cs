using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace do_an_nhom_15.Controllers
{
    public class ContactController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string email, string message)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
"INSERT INTO tbContact (Name, Email,Message, CreatedDate) " +
"VALUES ({0}, {1}, {2}, {3})",
name, email, message, DateOnly.FromDateTime(DateTime.Now));
                _context.SaveChanges();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
