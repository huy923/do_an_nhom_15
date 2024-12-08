using do_an_nhom_15.Areas.Admin.Controllers;
using do_an_nhom_15.Models;
using elFinder.NetCore.Helpers;
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
                order = order.Where(p => p.Customer.Name.Contains(searchTerm));
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
        public IActionResult Details(int id){
            var order = _context.Orders.Find(id);
            if(order == null){
                return Error("Sorry this customer is not in data");
            }
            
            ViewModel view = new(){
                OrderDetailList = [.. _context.OrderDetails.Where(p => p.OrderId == id).Include(od => od.Product)],
                Order = order
            };
            return View(view);
        }
        private IActionResult Error(string v)
        {
            throw new NotImplementedException();
        }
    }
}
    

