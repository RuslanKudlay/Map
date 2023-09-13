using BAL.Services.UserService;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Map.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllUser()
        //{
        //    return Ok(await _userService.GetAllUsers());
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateUser(User user)
        //{
        //    await _userService.CreateUser(user);
        //    return Ok();
        //}
    }
}
