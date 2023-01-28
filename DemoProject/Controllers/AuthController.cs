using DemoProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Services;
using Project.Data.Entities;
using System.Security.Claims;

namespace DemoProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(RegisterViewModel formdata)
        {
            if (!ModelState.IsValid)
            {
                return View(formdata);
            }
            var user = new UserEntity
            {
                FirstName = formdata.FirstName.Trim(),
                LastName = formdata.LastName.Trim(),
                Email = formdata.Email.Trim(),
                Password = formdata.Password.Trim(),
                UserType = Project.Data.Enums.UserTypeEnum.Client

            };
            var response = _userService.AddUser(user);
            if (response.IsSucceed)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = response.Message;
                return View(formdata);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginViewModel formData)
        {

            var user = _userService.Login(formData.Email, formData.Password);

            if (user is null)
            {
                TempData["LoginMessage"] = "Mail adresinizi ve ya şifreyi hatalı girdiniz.";

                return RedirectToAction("Login", "Auth");
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("firstName", user.FirstName));
            claims.Add(new Claim("lastName", user.LastName));
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("userType", user.UserType.ToString()));

            claims.Add(new Claim(ClaimTypes.Role, user.UserType.ToString()));

            // claim.Add(new Claim("password", user.Password)); --> BÜYÜK BİR GÜVENLİK AÇIĞI. PASSWORD KESİNLİKLE VE KESİNLİKLE CLAIM VEYA BAŞKA BIR YERDE TUTULMAZ.

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48))
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
                autProperties);


            return RedirectToAction("Index", "Home");
        }
    }
}
