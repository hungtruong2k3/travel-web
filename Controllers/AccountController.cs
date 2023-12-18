using Btl.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebDayHoc.Models;

namespace Btl.Controllers
{
    public class AccountController : Controller
    {
        private readonly BtlContext _context;

        public AccountController(BtlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("UserID,UserName,UserEmail,UserPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.User.FirstOrDefault(m => m.UserEmail == user.UserEmail);
                if (existingUser == null)
                {
                    // Kiểm tra xem tên người dùng đã được sử dụng chưa
                    var existingUsername = _context.User.FirstOrDefault(m => m.UserName == user.UserName);
                    if (existingUsername == null)
                    {
                        user.UserRole = "Customer"; // Set the user role to Customer
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "Tên người dùng đã được sử dụng.");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserEmail", "Email đã được sử dụng.");
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userFormPage)
        {
            var user = _context.User.FirstOrDefault(m => m.UserEmail == userFormPage.UserEmail && m.UserPassword == userFormPage.UserPassword);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserEmail),
                    new Claim("FullName", user.UserName),
                    new Claim(ClaimTypes.Role,user.UserRole),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginStatus = 0;
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
