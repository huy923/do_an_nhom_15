﻿using do_an_nhom_15.Areas.Admin.Controllers;
using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace do_an_nhom_15.Areas.admin.Controllers
{
    [Area("Admin")]
    public class BillController(CoffeeShopDbContext context) : AdminBaseController
    {
        private readonly CoffeeShopDbContext _context = context;
        public IActionResult Index(string searchTerm)
        {
            var order = _context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                order = order.Where(p => p.CustomerName.Contains(searchTerm));
            }
            ViewModel view = new()
            {
                OrderDetailList = [.. _context.OrderDetails.Include(c => c.Product)],
                OrderList = [.. order]
            };
            return View(view);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id){
            var order = _context.Orders.Find(id);
            return View(order);
        }
    }
}
    
