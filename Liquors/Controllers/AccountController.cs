using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liquors.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Liquors.Controllers
{
    public class AccountController : Controller
    {
        protected UserManager<IdentityUser> UserManager;
        protected SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            return Content("X");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(registerModel.Login);
                user.Email = registerModel.Email;
                IdentityResult identityResult = await UserManager.CreateAsync(user, registerModel.Password);
                if (identityResult.Succeeded)
                {
                    await SignInManager.PasswordSignInAsync(user, registerModel.Password, true, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerModel);
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            if (ModelState.IsValid)
            {
                SignInResult signInResult = await SignInManager.PasswordSignInAsync(logInModel.Login, logInModel.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Log in failed");
                }
            }

            return View(logInModel);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var signOutAsync = SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
