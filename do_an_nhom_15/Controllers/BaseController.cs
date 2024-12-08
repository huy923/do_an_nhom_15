using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace do_an_nhom_15.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CoffeeShopDbContext _context;

        public BaseController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.CartCount = _context.Carts.Sum(c => c.Quantity);
            base.OnActionExecuting(context);
        }

    }
}
