using BAL.Services.UserLocationService;
using Map.Attributes;
using Map.Helper;
using Map.Models;
using Microsoft.AspNetCore.Mvc;

namespace Map.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MapApiController : ControllerBase
    {
        private readonly IUserLocationService _userLocationService;
        public MapApiController(IUserLocationService userLocationService)
        {
            _userLocationService = userLocationService;
        }


        [CustomAuthorize]
        [HttpPost]
        [Route("create-point")]
        public async Task<IActionResult> CreatePoint([FromBody] LocationPoint locationPoint)
        {
            var userId = new Guid(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "userId").Value);

            var userLocation = UserHelper.Map(locationPoint);
            await _userLocationService.CreatePoints(userLocation, userId);
            return Ok();
        }
    }
}
