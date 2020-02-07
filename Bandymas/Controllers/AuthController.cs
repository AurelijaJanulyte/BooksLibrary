using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bandymas.Models;
using Bandymas.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Bandymas.Controllers
{
    [Route("Shared")]
    public class AuthController : Controller
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("SignIn")]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new SignIn());
        }

        [Route("SignIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignIn model,string returnUrl = null) 
        {
            if (ModelState.IsValid) 
            {
                User user;
                if (await _userService.ValidateCredentials(model.Username, model.Password, out user)) 
                {
                    await SignInUser(user.UserName);
                    if (returnUrl != null) 
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("/BooksList/List");
                }
            }
            return View(model);
        }

        [Route("signout")]
        [HttpPost]
        public async Task<IActionResult> SignOut() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("/BooksList/List");
        }
        public async Task SignInUser(string username) 
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim("name", username)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", null);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}