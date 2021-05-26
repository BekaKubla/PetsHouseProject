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

        public UserProductController(UserManager<AppUser> userManager,IVetRegistraitonRepo vetContext)
        {
            _userManager = userManager;
            _vetContext = vetContext;
        }
        public async Task<IActionResult> UserProducts(User user, VetRegistracion vetRegistracion)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = appUser.Email;
            user.UserName = appUser.UserName;
            var productList = _vetContext.GetAllVet(vetRegistracion).Where(e => e.UserName == user.UserName).ToList();
            return View(productList);
        }
    }
}
