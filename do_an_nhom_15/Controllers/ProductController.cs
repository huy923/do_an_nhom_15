using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace do_an_nhom_15.Controllers
{
    public class ProductController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index()
        {
            return View();
        }
        [Route("/product/{name}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewModel view = new()
            {
                ProductList = [.. _context.Products],
                SelectedProduct = product
            };
            return View(view);
        }

        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            var existingCartItem = _context.Carts.FirstOrDefaultAsync(p => p.ProductId == cart.ProductId).Result;

            if (existingCartItem != null)
            {
                int newQuantity = existingCartItem.Quantity + cart.Quantity;
                _context.Database.ExecuteSqlRaw("UPDATE Cart SET quantity = {0} WHERE product_id = {1}", newQuantity, cart.ProductId);
            }
            else
            {
                _context.Database.ExecuteSqlRaw("INSERT INTO Cart(product_id, quantity)" + "VALUES ({0}, {1})", cart.ProductId, cart.Quantity);
            }
            _context.SaveChanges();
            var refererUrl = Request.Headers.Referer.ToString();
            return Redirect(refererUrl);
        }
    }

}
