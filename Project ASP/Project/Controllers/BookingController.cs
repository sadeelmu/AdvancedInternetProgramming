using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
