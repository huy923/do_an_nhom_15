using do_an_nhom_15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace do_an_nhom_15.Controllers
{
    public class HomeController(ILogger<HomeController> logger, CoffeeShopDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly CoffeeShopDbContext _context = context;

        public IActionResult Index()
        {
            ViewModel view = new()
            {
                ProductList = [.. _context.Products]
            };

            ViewData["Blog"] = _context.Blogs.OrderDescending().Take(3).ToList();
            return View(view);
        }

        public IActionResult Menu()
        {
            ViewModel menu = new()
            {
                ProductList = [.. _context.Products]
            };
            return View(menu);
        }
        public IActionResult Services() { return View(); }
        public IActionResult Blog()
        {
            var item = _context.Blogs.Include(i => i.CommentBlogs).Include(i => i.Admin).ToList();
            return View("Blog", item);
        }
        public IActionResult About() { return View(); }
        public IActionResult Checkout() { return View(); }
        public IActionResult Contact() { return View(); }

        [Route("/Home/blog/{id}.html")]
        public IActionResult Blog_single(int id)
        {
          var item = _context.Blogs.Include(i => i.CommentBlogs).ThenInclude(i=>i.Customer).Include(i => i.Admin).Where(i=>i.BlogId == id).FirstOrDefault();
            ViewData["Blog"] = _context.Blogs.Include(i=>i.Admin).Include(i=>i.CommentBlogs).Where(i=>i.BlogId != id).OrderDescending().Take(3).ToList();
            return View("Blog_single", item);
        }
        public IActionResult Shop() { return View(); }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() { return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
    }
}
