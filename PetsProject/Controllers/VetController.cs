using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsProject.Models;
using PetsProject.Repositories;
using PetsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Controllers
{
    public class VetController : Controller
    {
        private readonly IVetRegistraitonRepo _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public VetController(IVetRegistraitonRepo vetRegistraitonRepo, Microsoft.AspNetCore.Identity.UserManager<AppUser>userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = vetRegistraitonRepo;
            _userManager = userManager;
            _env = webHostEnvironment;
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
            if (ModelState.IsValid)
            {
                if (vetRegistrationViewModel.VetPhoto != null)
                {
                    string folder = "Images/VetPhoto/";
                    folder += Guid.NewGuid().ToString() + "_" + vetRegistrationViewModel.VetPhoto.FileName;

                    vetRegistrationViewModel.VetImageUrl = "/"+folder;

                    string serverFolder = Path.Combine(_env.WebRootPath, folder);

                    await vetRegistrationViewModel.VetPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var vet = new VetRegistracion
                {
                    UserName = findUser.UserName,
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
                    VetphotoUrl=vetRegistrationViewModel.VetImageUrl
                };

                _context.RegisterVet(vet);
                _context.SaveChange();
                return RedirectToAction("Vet");
            }
            return View(vetRegistrationViewModel);
        }
        //customvet
        public IActionResult GetCustomVet(VetRegistracion vetRegistracion)
        {
            var findVetByCity = _context.GetAllVet(vetRegistracion).Where(e=>e.City==City.თბილისი);
            return View(findVetByCity);
        }
        [Authorize]
        public async Task<IActionResult> RemoveVet(int id)
        {
            var getVet = _context.GetVetById(id);
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (findUser.UserName == getVet.UserName)
            {
                _context.RemoveVet(getVet);
                _context.SaveChange();
                return RedirectToAction("UserProducts", "UserProduct");
            }
            else
            {
                TempData["Message"] = "მსგავსი განცხადება თქვენ არ გეკუთვნით";
                return RedirectToAction("Userproducts","UserProduct");
            }
        }

    }
}
