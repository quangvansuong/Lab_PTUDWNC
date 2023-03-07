using Microsoft.AspNetCore.Mvc;

namespace TatBlog.WebApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
            => View();

        public IActionResult contact() 
            => View();

        public IActionResult Rss() 
            => Content("Nội dung sẽ được cập nhật");
    }
}
