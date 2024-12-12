using Microsoft.AspNetCore.Mvc;
using do_an_nhom_15.Models;
using do_an_nhom_15.Areas.Admin.Controllers;
namespace do_an_nhom_15.Areas
{
    [Area("Admin")]
    public class HomeController(CoffeeShopDbContext context) : AdminBaseController
    {
        private readonly CoffeeShopDbContext _context = context;
        public IActionResult Index() { return View(); }
    }
}