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
                SelectedProduct = product,
                AddCart = new Cart()
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

        //[HttpPost]
        //public async Task<IActionResult> Add(int id, int quantity)
        //{
        //    Cart newcart = new()
        //    {
        //        ProductId = id,
        //        Quantity = quantity
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        // Kiểm tra sự tồn tại của sản phẩm
        //        var productExists = await _context.Products.AnyAsync(p => p.ProductId == id);
        //        if (!productExists)
        //        {
        //            ModelState.AddModelError("", "Sản phẩm không tồn tại.");
        //            return View(newcart);
        //        }

        //        // Kiểm tra nếu sản phẩm đã có trong giỏ hàng
        //        var existingCartItem = await _context.Carts
        //            .FirstOrDefaultAsync(c => c.ProductId == id);

        //        if (existingCartItem != null)
        //        {
        //            existingCartItem.Quantity += quantity;
        //            _context.Carts.Update(existingCartItem);
        //        }
        //        else
        //        {
        //            _context.Carts.Add(newcart);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Details", new { id = id });
        //    }

        //    return View(newcart);
        //}
    }

}
