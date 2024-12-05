using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace do_an_nhom_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController(CoffeeShopDbContext context) : AdminBaseController
    {
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index(string? searchTerm)
        {
            var employee = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    employee = employee.Where(p => p.FirstName != null && p.FirstName.Contains(searchTerm) || p.LastName != null && p.LastName.Contains(searchTerm));
                }
            }

            ViewModel model = new()
            {
                EmployeeList = [.. employee]
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid )
            {
                employee.HireDate = DateOnly.FromDateTime(DateTime.Now);
                _context.Database.ExecuteSqlRaw(
                "INSERT INTO employees (first_name, last_name, email, phone_number, position, salary, hire_date, status) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                employee.FirstName, employee.LastName, employee.Email, employee.PhoneNumber, employee.Position, employee.Salary, employee.HireDate, employee.Status);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.AsNoTracking().FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Remove() { return View(); }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var removeEmployee = _context.Employees.Find(id);
            if (removeEmployee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(removeEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}