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
        private readonly IPetRegistrationRepo _petContext;
        private readonly IVacancyRepo _vacancyContext;

        public Account(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager,IPasswordHasher<AppUser>passwordHasher,
                        IVetRegistraitonRepo vetRegistraitonRepo,IPetRegistrationRepo petRegistrationRepo,IVacancyRepo vacancyRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _vetContext = vetRegistraitonRepo;
            _petContext = petRegistrationRepo;
            _vacancyContext = vacancyRepo;
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
                    Email = user.Email,
                    GenderValue=user.UserGender

                };
                var findUser = await _userManager.FindByEmailAsync(appUser.Email);
                if (findUser != null)
                {
                    while (findUser != null)
                    {
                        ModelState.AddModelError("", "ელ-ფოსტა " + appUser.Email + " გამოყენებულია,სცადეთ სხვა ელ-ფოსტა");
                        return View(user);
                    }
                }
                var userResult = await _userManager.CreateAsync(appUser, user.Password);
                if (userResult.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("UserProfile");
                }
                else
                {
                    foreach(var item in userResult.Errors)
                    {
                        if (item.Code == "DuplicateUserName")
                        {
                            ModelState.AddModelError("","სახელი "+appUser.UserName +" გამოყენებულია,სცადეთ სხვა სახელი");
                        }
                        else if(item.Code== "PasswordTooShort")
                        {
                            ModelState.AddModelError("", "პაროლი უნდა შეიცავდეს 4 სიმბოლოზე მეტს");
                        }
                        else if(item.Code== "PasswordRequiresUpper")
                        {
                            ModelState.AddModelError("", "პაროლი უნდა შეიცავდეს ერთ დიდ სიმბოლოს");
                        }
                    }
                }
            }
            return View(user);

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
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
                        return RedirectToAction("UserProfile");
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
            user.GenderValue = appUser.GenderValue;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEdit userEdit)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var findUser = await _userManager.FindByEmailAsync(userEdit.Email);
                if (userEdit.Email != appUser.Email)
                {
                    if (findUser != null)
                    {
                        ModelState.AddModelError("", "ელ-ფოსტა " + userEdit.Email + " უკვე გამოყენებულია,სცადეთ სხვა ელ-ფოსტა");
                        ModelState.FirstOrDefault(x => x.Key == nameof(userEdit.Email)).Value.RawValue = appUser.Email;
                        return View(userEdit);
                    }
                    else
                    {
                        appUser.Email = userEdit.Email;
                        appUser.GenderValue = userEdit.GenderValue;
                    }
                }
                if (userEdit.Password != null)
                {
                    if (userEdit.Password.Length <= 4)
                    {
                        ModelState.AddModelError("", "პაროლი უნდა შეიცავდეს 4 სიმბოლოზე მეტს.");
                        return View(userEdit);
                    }
                    else
                    {
                        appUser.PasswordHash = _passwordHasher.HashPassword(appUser, userEdit.Password);
                    }
                }
                appUser.GenderValue = userEdit.GenderValue;
                IdentityResult result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserProfile");
                }
            }
            return View(userEdit);
        }

        public async Task< IActionResult> UserProfile(User user,VetRegistracion vetRegistracion,PetRegistration petRegistration,JobVacancy jobVacancy)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = appUser.Email;
            user.UserName = appUser.UserName;
            if (appUser.GenderValue == 0)
            {
                user.UserGender = 0;
            }
            else
            {
                user.UserGender = 1;
            }
            user.VetCount = _vetContext.GetAllVet(vetRegistracion).Where(e => e.UserName == user.UserName).ToList().Count();
            user.PetCount = _petContext.GetAllPet(petRegistration).Where(e => e.UserName == user.UserName).ToList().Count();
            user.VacancyCount = _vacancyContext.GetAllJob(jobVacancy).Where(e => e.UserName == user.UserName).ToList().Count();
            return View(user);
        }
    }
}
