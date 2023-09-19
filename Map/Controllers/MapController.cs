using BAL.Services.UserLocationService;
using Microsoft.AspNetCore.Mvc;

namespace Map.Controllers
{
    public class MapController : Controller
    {
        private readonly IUserLocationService _userLocationService;
        public MapController(IUserLocationService userLocationService)
        {
            _userLocationService = userLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> Points()
        {
            var points = await _userLocationService.GetAllPoints();

            return Json(points);
        }
    }
}
