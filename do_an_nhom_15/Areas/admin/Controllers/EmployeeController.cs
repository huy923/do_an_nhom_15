using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;

namespace do_an_nhom_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController(CoffeeShopDbContext context) : Controller
    {
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index()
        {
            ViewModel Employee = new()
            {
                EmployeeList = [.. _context.Employees],
            };
            return View(Employee);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.HireDate = DateTime.Now;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();                
            }
            var mn = _context.Employees.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        public IActionResult Remove(int id)
        {
            var removeEmployee = _context.Employees.Find(id);
            if(removeEmployee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(removeEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}