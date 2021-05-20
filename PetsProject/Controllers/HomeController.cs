using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult blog_single()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult gallery()
        {
            return View();
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult main()
        {
            return View(); 
        }
        public IActionResult pricing()
        {
            return View();
        }
        public IActionResult services()
        {
            return View();
        }
        public IActionResult vet()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
