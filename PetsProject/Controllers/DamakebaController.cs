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
    public class DamakebaController : Controller
    {
        private readonly IDamakebaNoDocumentRepo _damakebaNoDoucument;

        public DamakebaController(IDamakebaNoDocumentRepo damakebaNoDocument)
        {
            _damakebaNoDoucument = damakebaNoDocument;
        }
        [HttpGet]
        public IActionResult WithDocument()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WithDocument(Damakeba damakeba,int id)
        {
            if (ModelState.IsValid)
            {
                damakeba.Published = DateTime.Now;
                damakeba.Document = "საბუთით";
                _damakebaNoDoucument.CreateProduct(damakeba);
                _damakebaNoDoucument.SaveChange();
                return RedirectToAction("Details", new { id = damakeba.ID });
            }
            return View();
        }


















        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Products(Damakeba damakebaNoDocument)
        {
            return View(_damakebaNoDoucument.GetAllProduct(damakebaNoDocument));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_damakebaNoDoucument.GetProductById(id));
        }
        [HttpGet]
        public IActionResult NoDocument()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NoDocument(Damakeba damakeba,int id)
        {
            if (ModelState.IsValid)
            {
                damakeba.Published = DateTime.Now;
                damakeba.Document = "საბუთის გარეშე";
                _damakebaNoDoucument.CreateProduct(damakeba);
                _damakebaNoDoucument.SaveChange();
                return RedirectToAction("Details",new { id = id });
            }
            return View();
        }
    }
}
