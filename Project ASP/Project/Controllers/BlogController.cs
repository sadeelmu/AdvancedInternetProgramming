using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
