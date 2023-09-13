using Microsoft.AspNetCore.Mvc;

namespace Map.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}