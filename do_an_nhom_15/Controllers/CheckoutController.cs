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
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                _context.Orders.Add(order);
                _context.SaveChanges();
                foreach (var item in _context.Carts.ToList())
                {
                    OrderDetail newOrder = new()
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    if (ModelState.IsValid)
                    {
                        _context.OrderDetails.Add(newOrder);
                    }
                    var product = _context.Products.Find(item.ProductId);
                    if (product != null)
                    {
                        product.Stock -= newOrder.Quantity;
                        _context.Products.Update(product);
                    }
                }


                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", order);
        }
    }
}
