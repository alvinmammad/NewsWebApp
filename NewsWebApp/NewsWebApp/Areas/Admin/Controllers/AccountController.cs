using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Areas.Admin.Models;
using NewsWebApp.Models;

namespace NewsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    bool isAdmin = await userManager.IsInRoleAsync(user, "Admin");
                    if (isAdmin)
                    {
                        var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        if (signInResult.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email or password is incorrect");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You dont have permission to enter the system!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bele bir user yoxdur blyet!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}