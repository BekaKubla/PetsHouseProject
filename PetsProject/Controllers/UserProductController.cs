using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsProject.Models;
using PetsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Controllers
{
    public class UserProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IVetRegistraitonRepo _vetContext;
        private readonly IPetRegistrationRepo _petContext;

        public UserProductController(UserManager<AppUser> userManager,IVetRegistraitonRepo vetContext,IPetRegistrationRepo petContext)
        {
            _userManager = userManager;
            _vetContext = vetContext;
            _petContext = petContext;
        }
        public async Task<IActionResult> VetProducts(User user, VetRegistracion vetRegistracion)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = appUser.Email;
            user.UserName = appUser.UserName;
            var productList = _vetContext.GetAllVet(vetRegistracion).Where(e => e.UserName == user.UserName).ToList();
            return View(productList);
        }
        public async Task<IActionResult> PetProducts(User user, PetRegistration petRegistracion)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = appUser.Email;
            user.UserName = appUser.UserName;
            var productList = _petContext.GetAllPet(petRegistracion).Where(e => e.UserName == user.UserName).ToList();
            return View(productList);
        }
    }
}
