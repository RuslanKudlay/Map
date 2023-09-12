using BAL.Services.UserService;
using Map.Helper;
using Map.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Map.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
                _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterUserView registerUserView)
        {
            if (!ModelState.IsValid)
            {
                return View(registerUserView);
            }

            var user = UserHelper.Map(registerUserView);
            var res = await _userService.CreateUser(user);

            if (res == true)
            {
                var claims = new List<Claim>
                {
                    new Claim("Demo", "Value")
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync("Cookie", claimPrincipal);
                return Redirect("/Admin/Login");
            }

            TempData["ErrorMessage"] = "User with this login already exists!";
            return Redirect("/Admin/Register");

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginUserView loginUserView)
        {
            var user = UserHelper.Map(loginUserView);
            var userCheck = await _userService.CompareUserByLoginAndPassword(user); 
            if (userCheck == true)
            {
                return Redirect("/Map/Index");
            }
            return View(loginUserView);
            
        }

       

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync("Cookie");

            return Redirect("/Home/Index");
        }
    }
}
