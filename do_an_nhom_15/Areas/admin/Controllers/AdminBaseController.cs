using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace do_an_nhom_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // check cookies is login or not 
            if (!Request.Cookies.TryGetValue("AdminLoggedIn", out var loggedIn) || loggedIn != "true")
            {
                // if not go back to index 
                context.Result = RedirectToAction("Index", "Login", new { area = "Admin" });
            }

            base.OnActionExecuting(context);
        }
    }
}
