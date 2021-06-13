using Microsoft.AspNetCore.Mvc;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Controllers
{
    public class VacancyController : Controller
    {
        [HttpGet]
        public IActionResult CreateVacancy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateVacancy(JobVacancy jobVacancy)
        {
            if (ModelState.IsValid)
            {
                return View(jobVacancy);
            }
            return View();
        }
    }
}
