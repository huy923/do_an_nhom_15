﻿using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

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
        
        
    }
}
