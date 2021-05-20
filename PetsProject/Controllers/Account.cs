using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsProject.Models;
using PetsProject.Repositories;
using PetsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Controllers
{
    [Authorize]
    public class Account : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IVetRegistraitonRepo _vetContext;

        public Account(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager,IPasswordHasher<AppUser>passwordHasher,
                        IVetRegistraitonRepo vetRegistraitonRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _vetContext = vetRegistraitonRepo;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email = user.Email
                };
                var userResult = await _userManager.CreateAsync(appUser, user.Password);
                if (userResult.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var item in userResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(user);

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(Login login)
        {

            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                    ModelState.AddModelError("", "შეყვანილი ინფორმაცია არასწორია.");
            }
            return View(login);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> UserEdit()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEdit user = new UserEdit(appUser);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEdit userEdit)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                appUser.Email = userEdit.Email;
                if (userEdit.Password != null)
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, userEdit.Password);
                }
                IdentityResult result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }

        public async Task< IActionResult> UserProfile(User user,VetRegistracion vetRegistracion)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = appUser.Email;
            user.UserName = appUser.UserName;
            user.VetCount = _vetContext.GetAllVet(vetRegistracion).Where(e => e.Email == user.Email).ToList().Count();
            return View(user);
        }
    }
}
