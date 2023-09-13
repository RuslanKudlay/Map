using BAL.Services.UserLocationService;
using Map.Attributes;
using Map.Helper;
using Map.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult Index()
        {
            return View();
        }


        [CustomAuthorize]
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] LocationPoint locationPoint)
        {
            var userId = new Guid(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "userId").Value);

            var userLocation = UserHelper.Map(locationPoint);
            await _userLocationService.CreatePoints(userLocation, userId);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Points()
        {
            var points = await _userLocationService.GetAllPoints();

            return Json(points);
        }
    }
}
