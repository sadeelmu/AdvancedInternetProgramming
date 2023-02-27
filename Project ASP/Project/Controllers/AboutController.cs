using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
