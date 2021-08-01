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
        [HttpGet]
        public IActionResult Vet(VetRegistracion vetRegistracion)
        {
            var getAll = _context.GetAllVet(vetRegistracion).OrderByDescending(e=>e.RegistrationDateTime).ToList();
            return View(getAll);
        }
        [HttpPost]
        public IActionResult Vet(string searchCity, string searchString,VetRegistracion vetRegistracion)
        {
            if (searchString == null && searchCity == null)
            {
                var getAllVet = _context.GetAllVet(vetRegistracion)
                                .OrderByDescending(e=>e.RegistrationDateTime);
                return View(getAllVet);
            }
            else if (searchString != null && searchCity == null)
            {
                var getVetBySearch = _context.GetAllVet(vetRegistracion)
                                    .OrderByDescending(e => e.RegistrationDateTime)
                                    .Where(e => e.Name.ToLower().Contains(searchString.ToLower())
                                    || e.Surname.ToLower().Contains(searchString.ToLower())
                                    || e.PhoneNumber.Contains(searchString));
                return View(getVetBySearch);
            }
            else if (searchCity != null && searchString == null)
            {
                var getVetByCity = _context.GetAllVet(vetRegistracion)
                                  .OrderByDescending(e => e.RegistrationDateTime)
                                  .Where(e => e.City.ToString().Contains(searchCity));
                return View(getVetByCity);
            }
            else if (searchString != null && searchCity != null)
            {
                var getVetByBoth = _context.GetAllVet(vetRegistracion)
                                   .OrderByDescending(e => e.RegistrationDateTime)
                                   .Where(e => e.City.ToString().Contains(searchCity))
                                   .Where(e => e.Name.ToLower().Contains(searchString.ToLower())
                                   || e.Surname.ToLower().Contains(searchString)
                                   ||e.PhoneNumber.Contains(searchString));
                return View(getVetByBoth);
            }
            return View();
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
                    RegistrationDateTime=DateTime.Now,
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
                return RedirectToAction("VetDetails", "Vet", new { id = vet.ID });
            }
            return View();
        }
        [HttpGet]
        public IActionResult VetEdit(int id)
        {
            var getVet = _context.GetVetById(id);
            VetRegistrationViewModel vetRegistracion = new VetRegistrationViewModel
            {
                Name = getVet.Name,
                Surname = getVet.Surname,
                Age = getVet.Age,
                Adress = getVet.Adress,
                City = getVet.City,
                Email = getVet.Email,
                PhoneNumber = getVet.PhoneNumber,
                Position = getVet.Position,
                About = getVet.About,
                CompanyName = getVet.CompanyName,
            };
            return View(vetRegistracion);
        }
        [HttpPost]
        public async Task<IActionResult> VetEdit(VetRegistrationViewModel vetRegistrationViewModel,int id)
        {
            var findVet = _context.GetVetById(id);
            if (findVet == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (vetRegistrationViewModel.VetPhoto != null)
                    {
                        string folder = "Images/VetPhoto/";
                        folder += Guid.NewGuid().ToString() + "_" + vetRegistrationViewModel.VetPhoto.FileName;

                        vetRegistrationViewModel.VetImageUrl = "/" + folder;

                        string serverFolder = Path.Combine(_env.WebRootPath, folder);

                        await vetRegistrationViewModel.VetPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    }
                    findVet.Name = vetRegistrationViewModel.Name;
                    findVet.Surname = vetRegistrationViewModel.Surname;
                    findVet.Age = vetRegistrationViewModel.Age;
                    findVet.Adress = vetRegistrationViewModel.Adress;
                    findVet.City = vetRegistrationViewModel.City;
                    findVet.PhoneNumber = vetRegistrationViewModel.PhoneNumber;
                    findVet.Position = vetRegistrationViewModel.Position;
                    findVet.About = vetRegistrationViewModel.About;
                    findVet.CompanyName = vetRegistrationViewModel.CompanyName;
                    if (vetRegistrationViewModel.VetImageUrl == null)
                    {
                        vetRegistrationViewModel.VetImageUrl = findVet.VetphotoUrl;
                    }
                    else
                    {
                        findVet.VetphotoUrl = vetRegistrationViewModel.VetImageUrl;
                    }
                    _context.SaveChange();
                    return RedirectToAction("VetDetails", "Vet", new { id = findVet.ID });
                }
            }
            return View();
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
                return RedirectToAction("VetProducts", "UserProduct");
            }
            else
            {
                TempData["Message"] = "მსგავსი განცხადება თქვენ არ გეკუთვნით";
                return RedirectToAction("VetProducts", "UserProduct");
            }
        }

    }
}
