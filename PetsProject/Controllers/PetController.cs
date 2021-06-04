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
    public class PetController : Controller
    {
        private readonly IPetRegistrationRepo _petRegistrationRepo;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public PetController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IPetRegistrationRepo petRegistrationRepo, IWebHostEnvironment webHostEnvironment)
        {
            _petRegistrationRepo = petRegistrationRepo;
            _env = webHostEnvironment;
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult PetReg()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PetRegAsync(PetRegistrationViewModel petRegistrationViewModel)
        {
            if (ModelState.IsValid)
            {
                if (petRegistrationViewModel.PetPhoto != null)
                {
                    string folder = "Images/PetPhoto/";
                    folder += Guid.NewGuid().ToString() + "_" + petRegistrationViewModel.PetPhoto.FileName;

                    petRegistrationViewModel.PetPhotoUrl = "/" + folder;

                    string serverFolder = Path.Combine(_env.WebRootPath, folder);

                    await petRegistrationViewModel.PetPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
                PetRegistration petRegistration = new PetRegistration()
                {
                    UserName = findUser.UserName,
                    Age = petRegistrationViewModel.Age,
                    City = petRegistrationViewModel.City,
                    ContactName = petRegistrationViewModel.ContactName,
                    PetPhotoUrl = petRegistrationViewModel.PetPhotoUrl,
                    PhoneNumber = petRegistrationViewModel.PhoneNumber,
                    Price = petRegistrationViewModel.Price,
                    Subject = petRegistrationViewModel.Subject,
                    Title = petRegistrationViewModel.Title


                };
                _petRegistrationRepo.RegisterPet(petRegistration);
                _petRegistrationRepo.SaveChange();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetPets(PetRegistration petRegistration)
        {
            var getAllPet = _petRegistrationRepo.GetAllPet(petRegistration);
            return View(getAllPet);
        }
        [HttpPost]
        public IActionResult GetPets(string searchString,string searchJishebi,string searchSex,string searchCity,PetRegistration petRegistration)
        {
            var getAllPet = _petRegistrationRepo.GetAllPet(petRegistration);
            if(searchString == null && searchJishebi == null && searchSex == null && searchCity == null)
            {
                return View(getAllPet);
            }
            if (searchString != null && searchJishebi == null && searchSex == null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString == null && searchJishebi != null && searchSex == null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Jishebi.ToString() == searchJishebi));
            }
            if(searchString == null && searchJishebi == null && searchSex != null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Sex.ToString() == searchSex));
            }
            if(searchString == null && searchJishebi == null && searchSex == null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity));
            }
            if(searchString != null && searchJishebi != null && searchSex == null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Jishebi.ToString() == searchJishebi)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if (searchString == null && searchJishebi == null && searchSex != null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                                     .Where(e => e.Sex.ToString() == searchSex));
            }
            if(searchString != null && searchJishebi == null && searchSex != null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Sex.ToString() == searchSex)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString == null && searchJishebi != null && searchSex == null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                                     .Where(e => e.Jishebi.ToString() == searchJishebi));
            }
            if(searchString != null && searchJishebi == null && searchSex == null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString == null && searchJishebi != null && searchSex != null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Jishebi.ToString() == searchJishebi)
                                     .Where(e => e.Sex.ToString() == searchSex));
            }
            if(searchString != null && searchJishebi != null && searchSex != null && searchCity == null)
            {
                return View(getAllPet.Where(e => e.Jishebi.ToString() == searchJishebi)
                                     .Where(e => e.Sex.ToString() == searchSex)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString == null && searchJishebi != null && searchSex != null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                                     .Where(e => searchJishebi.ToString() == searchJishebi)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString != null && searchJishebi == null && searchSex != null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                                     .Where(e => e.Sex.ToString() == searchSex)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString != null && searchJishebi != null && searchSex == null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                                     .Where(e => e.Jishebi.ToString() == searchJishebi)
                                     .Where(e => e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }
            if(searchString != null && searchJishebi != null && searchSex != null && searchCity != null)
            {
                return View(getAllPet.Where(e => e.City.ToString() == searchCity)
                           .Where(e=>e.Sex.ToString()==searchSex)
                           .Where(e=>e.Jishebi.ToString()==searchJishebi)
                           .Where(e=>e.Title.Contains(searchString) || e.PhoneNumber == searchString));
            }


            return View();
        }
        [Authorize]
        public IActionResult RemovePet(int id)
        {
            var findPet = _petRegistrationRepo.GetPetById(id);
            _petRegistrationRepo.RemovePet(findPet);
            _petRegistrationRepo.SaveChange();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult PetDetails(int id)
        {
            var findPet = _petRegistrationRepo.GetPetById(id);
            return View(findPet);
        }
        [HttpGet]
        public IActionResult PetEdit(int id)
        {
            var findPetById = _petRegistrationRepo.GetPetById(id);
            PetRegistrationViewModel petRegistrationViewModel = new PetRegistrationViewModel()
            {
                Age = findPetById.Age,
                City = findPetById.City,
                ContactName = findPetById.ContactName,
                Jishebi = findPetById.Jishebi,
                PetPhotoUrl = findPetById.PetPhotoUrl,
                PhoneNumber = findPetById.PhoneNumber,
                Price = findPetById.Price,
                Sex = findPetById.Sex,
                Subject = findPetById.Subject,
                Title = findPetById.Title
            };
            return View(petRegistrationViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PetEditAsync(PetRegistrationViewModel petRegistrationViewModel,int id)
        {
            var findPet = _petRegistrationRepo.GetPetById(id);
            findPet.Age = petRegistrationViewModel.Age;
            findPet.City = petRegistrationViewModel.City;
            findPet.ContactName = petRegistrationViewModel.ContactName;
            findPet.Jishebi = petRegistrationViewModel.Jishebi;
            findPet.Price = petRegistrationViewModel.Price;
            findPet.PhoneNumber = petRegistrationViewModel.PhoneNumber;
            findPet.Sex = petRegistrationViewModel.Sex;
            findPet.Subject = petRegistrationViewModel.Subject;
            findPet.Title = petRegistrationViewModel.Title;
            if (petRegistrationViewModel.PetPhoto != null)
            {
                string folder = "Images/PetPhoto/";
                folder += Guid.NewGuid().ToString() + "_" + petRegistrationViewModel.PetPhoto.FileName;

                petRegistrationViewModel.PetPhotoUrl = "/" + folder;

                string serverFolder = Path.Combine(_env.WebRootPath, folder);

                await petRegistrationViewModel.PetPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            if (petRegistrationViewModel.PetPhotoUrl == null)
            {
                petRegistrationViewModel.PetPhotoUrl = findPet.PetPhotoUrl;
            }
            else
            {
                findPet.PetPhotoUrl = petRegistrationViewModel.PetPhotoUrl;
            }
            _petRegistrationRepo.SaveChange();
            return RedirectToAction("PetDetails", "Pet",new { id = id });
        }
    }
}
