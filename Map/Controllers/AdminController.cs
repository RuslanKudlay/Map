using BAL.Services.UserService;
using Map.Helper;
using Map.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Map.Controllers
{
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
            var isCreated = await _userService.CreateUser(user);

            if (isCreated == true)
            {
                return Redirect("/Admin/Login");
            }

            TempData["ErrorMessage"] = "User with this login already exists!";
            return Redirect("/Admin/Register");

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginUserView loginUserView)
        {
            var user = UserHelper.Map(loginUserView);
            var isValidUser = await _userService.CompareUserByLoginAndPassword(user); 
            if (isValidUser == true)
            {
                var userId = await _userService.GetUserByLoginAndPassword(loginUserView.Login, loginUserView.Password);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, loginUserView.Login),
                    new Claim("userId", userId.ToString())
                };
                var claimIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity),
                    new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(5) });


                return Redirect("/Home/Index");
            }
            return View(loginUserView);
            
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Home/Index");
        }
    }
}
