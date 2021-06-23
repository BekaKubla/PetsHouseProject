using Microsoft.AspNetCore.Authorization;
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
    public class VacancyController : Controller
    {
        private readonly IVacancyRepo _vacancyRepo;
        private readonly UserManager<AppUser> _userManager;

        public VacancyController(IVacancyRepo vacancyRepo, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _vacancyRepo = vacancyRepo;
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreateVacancy()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateVacancy(JobVacancy jobVacancy)
        {
            if (ModelState.IsValid)
            {
                jobVacancy.Published = DateTime.Now;
                jobVacancy.UserName = User.Identity.Name;
                _vacancyRepo.CreateJob(jobVacancy);
                _vacancyRepo.SaveChange();
                return RedirectToAction("GetAllVacancy");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetAllVacancy(JobVacancy jobVacancy)
        {
            return View(_vacancyRepo.GetAllJob(jobVacancy).OrderByDescending(e=>e.Published));
        }
        [HttpPost]
        public IActionResult GetAllVacancy(string searchCity, string searchSallary, string searchString, JobVacancy jobVacancy)
        {
            if (searchString != null && searchSallary != null && searchCity != null)
            {
                if (searchSallary == "ზრდადი >")
                {
                    return View(_vacancyRepo.GetAllJob(jobVacancy).OrderByDescending(e => e.Published)
                                                                  .OrderBy(e => e.Sallary)
                                                                  .Where(e => e.City.ToString()
                                                                  .StartsWith(searchCity)).Where(e => e.JobName.StartsWith(searchString)));
                }
                else if (searchSallary == "კლებადი <")
                {
                    return View(_vacancyRepo.GetAllJob(jobVacancy)
                                            .OrderByDescending(e => e.Published)
                                            .OrderByDescending(e => e.Sallary)
                                            .Where(e => e.City.ToString()
                                            .StartsWith(searchCity)).Where(e => e.JobName.StartsWith(searchString)));
                }
            }
            else if (searchString != null && searchSallary == null && searchCity == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .Where(e => e.JobName.StartsWith(searchString)));
            }
            else if (searchSallary == "ზრდადი >" && searchString == null && searchCity == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .OrderBy(e => e.Sallary));
            }
            else if (searchSallary == "კლებადი <" && searchString == null && searchCity == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .OrderByDescending(e => e.Sallary));
            }
            else if (searchCity != null && searchString == null && searchSallary == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .Where(e => e.City.ToString().StartsWith(searchCity)));
            }
            else if (searchCity != null && searchString != null && searchSallary == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .Where(e => e.City.ToString()
                                        .StartsWith(searchCity))
                                        .Where(e => e.JobName.StartsWith(searchString)));
            }
            else if (searchSallary == "ზრდადი >" && searchString != null && searchCity == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .OrderBy(e => e.Sallary)
                                        .Where(e => e.JobName.StartsWith(searchString)));
            }
            else if (searchSallary == "კლებადი <" && searchString != null && searchCity == null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .OrderByDescending(e => e.Sallary)
                                        .Where(e => e.JobName.StartsWith(searchString)));
            }
            else if (searchSallary == "ზრდადი >" && searchString == null && searchCity != null) 
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                        .OrderByDescending(e => e.Published)
                        .OrderBy(e => e.Sallary)
                        .Where(e => e.City.ToString().StartsWith(searchCity)));
            }
            else if (searchSallary == "კლებადი <" && searchString == null && searchCity != null)
            {
                return View(_vacancyRepo.GetAllJob(jobVacancy)
                                        .OrderByDescending(e => e.Published)
                                        .OrderByDescending(e => e.Sallary)
                                        .Where(e => e.City.ToString().StartsWith(searchCity)));
            }
            return View(_vacancyRepo.GetAllJob(jobVacancy).OrderByDescending(e => e.Published));
        }
        public IActionResult GetVacancyById(int id)
        {
            var findVacancy = _vacancyRepo.GetJobById(id);
            return View(findVacancy);
        }
        [Authorize]
        public async Task <IActionResult> RemoveVacancy(int id)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findVacancy = _vacancyRepo.GetJobById(id);
            if (findUser.UserName == findVacancy.UserName)
            {
                _vacancyRepo.RemoveJob(findVacancy);
                _vacancyRepo.SaveChange();
                return RedirectToAction("Vacancys", "UserProduct");
            }
            else
            {
                ModelState.AddModelError("", "მსგავსი განცხადება თქვენ არ გეკუთვნით");
            }
            return RedirectToAction("Vacancys", "UserProduct");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateVacancy(int id)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findVacancy = _vacancyRepo.GetJobById(id);
            if (findUser.UserName == findVacancy.UserName)
            {
                JobVacancy jobVacancy = new JobVacancy()
                {
                    Age = findVacancy.Age,
                    City = findVacancy.City,
                    EmployerName = findVacancy.EmployerName,
                    EndTime = findVacancy.EndTime,
                    FullDescription = findVacancy.FullDescription,
                    JobDescription = findVacancy.JobDescription,
                    JobName = findVacancy.JobName,
                    PersonSex = findVacancy.PersonSex,
                    PhoneNumber = findVacancy.PhoneNumber,
                    Sallary = findVacancy.Sallary,
                    StartTime = findVacancy.StartTime,
                    Week = findVacancy.Week,
                    UserName = findVacancy.UserName,
                    Published = findVacancy.Published,
                };
                return View(jobVacancy);
            }
            else
            {
                ModelState.AddModelError("VacancyUpdateAuthorize", "მსგავსი განცხადება თქვენ არ გეკუთვნით");
            }
            return RedirectToAction("Vacancys", "UserProduct");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateVacancy(int id,JobVacancy jobVacancy)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findVacancy = _vacancyRepo.GetJobById(id);
            if (findUser.UserName == findVacancy.UserName)
            {
                if (ModelState.IsValid)
                {
                    findVacancy.Age = jobVacancy.Age;
                    findVacancy.City = jobVacancy.City;
                    findVacancy.EmployerName = jobVacancy.EmployerName;
                    findVacancy.EndTime = jobVacancy.EndTime;
                    findVacancy.FullDescription = jobVacancy.FullDescription;
                    findVacancy.JobDescription = jobVacancy.JobDescription;
                    findVacancy.JobName = jobVacancy.JobName;
                    findVacancy.PersonSex = jobVacancy.PersonSex;
                    findVacancy.PhoneNumber = jobVacancy.PhoneNumber;
                    findVacancy.Sallary = jobVacancy.Sallary;
                    findVacancy.StartTime = jobVacancy.StartTime;
                    findVacancy.Week = jobVacancy.Week;
                    jobVacancy.UserName=findVacancy.UserName;
                    jobVacancy.Published = findVacancy.Published;
                    _vacancyRepo.SaveChange();
                    return RedirectToAction("GetVacancyById", "Vacancy", new { id = id });
                }
                return View();
            }
            else
            {
                ModelState.AddModelError("", "მსგავსი განცხადება თქვენ არ გეკუთვნით");
            }
            return View();
        }
    }
}
