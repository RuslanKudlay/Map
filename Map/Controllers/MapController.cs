using Microsoft.AspNetCore.Mvc;

namespace Map.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
