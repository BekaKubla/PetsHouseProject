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
    public class VetController : Controller
    {
        private readonly IVetRegistraitonRepo _context;
        private readonly UserManager<AppUser> _userManager;

        public VetController(IVetRegistraitonRepo vetRegistraitonRepo, Microsoft.AspNetCore.Identity.UserManager<AppUser>userManager)
        {
            _context = vetRegistraitonRepo;
            _userManager = userManager;
        }
        public IActionResult Vet(VetRegistracion vetRegistracion)
        {
            var getAll = _context.GetAllVet(vetRegistracion);
            return View(getAll);
        }
        public IActionResult VetDetails(int id)
        {
            var getVetById = _context.GetVetById(id);
            return View(getVetById);
        }
        [Authorize]
        [HttpGet]
        public IActionResult VetRegistration()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> VetRegistration(VetRegistrationViewModel vetRegistrationViewModel)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var vet = new VetRegistracion
            {
                Name = vetRegistrationViewModel.Name,
                Surname = vetRegistrationViewModel.Surname,
                Age = vetRegistrationViewModel.Age,
                Adress = vetRegistrationViewModel.Adress,
                City = vetRegistrationViewModel.City,
                Email = findUser.Email,
                PhoneNumber = vetRegistrationViewModel.PhoneNumber,
                Position = vetRegistrationViewModel.Position,
                About = vetRegistrationViewModel.About,
                CompanyName = vetRegistrationViewModel.CompanyName,
            };
            _context.RegisterVet(vet);
            _context.SaveChange();
            return RedirectToAction("Vet");
        }

    }
}
