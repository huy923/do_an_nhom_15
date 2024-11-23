using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace do_an_nhom_15.Controllers
{
    public class CartController(ILogger<HomeController> logger, CoffeeShopDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index()
        {
            ViewModel view = new()
            {
                CartList = [.. _context.Carts.Include(c => c.Product)],
                ProductList = [.. _context.Products]
            };
            return View(view);
        }
        [HttpPost]
        public IActionResult ProductAdd(int id)
        {
            if (ModelState.IsValid)
            {
                var existingCartItem = _context.Carts.FirstOrDefault(c => c.ProductId == id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += 1;
                    _context.Carts.Update(existingCartItem);
                }
                else
                {
                    var cart = new Cart
                    {
                        ProductId = id,
                        Quantity = 1
                    };
                    _context.Carts.Add(cart);
                }
                _context.SaveChanges();
                return RedirectToAction("Details", "Product"); 
            }
            return BadRequest("Dữ liệu không hợp lệ");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            if (ModelState.IsValid)
            {
                var existingCartItem = _context.Carts.FirstOrDefault(c => c.ProductId == cart.ProductId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += cart.Quantity;
                    _context.Carts.Update(existingCartItem);
                }
                else
                {
                    _context.Carts.Add(cart);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            return View(cart); 
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
