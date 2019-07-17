using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Core;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.Models.ViewModels;

namespace NewsWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly NewsDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountController(NewsDbContext db,
                                    UserManager<User> userManager,
                                            SignInManager<User> signInManager)
        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.UsernameEmail);

                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(model.UsernameEmail);
                }


                if (user != null)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsPresistent, true);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Email incorrect");
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            await LayoutInitializer.FillCategories(_db,ViewBag);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Username
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (createResult.Succeeded)
                {
                    var signInResult= await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}