 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using do_an_nhom_15.Models;
using Microsoft.EntityFrameworkCore;
namespace do_an_nhom_15.Controllers
{
    public class CheckoutController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Today;
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(order);
        }

        
    }
}
