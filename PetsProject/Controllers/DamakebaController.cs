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
    public class DamakebaController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDamakebaNoDocumentRepo _damakebaNoDoucument;

        public DamakebaController(IDamakebaNoDocumentRepo damakebaNoDocument, IWebHostEnvironment webHostEnvironment, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _env = webHostEnvironment;
            _userManager = userManager;
            _damakebaNoDoucument = damakebaNoDocument;
        }
        [Authorize]
        [HttpGet]
        public IActionResult WithDocument()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> WithDocument(DamakebaViewModel damakebaViewModel,int id)
        {
            if (ModelState.IsValid)
            {
                if (damakebaViewModel.DamakebaPhoto != null)
                {
                    string folder = "Images/DamakebaPhoto/";
                    folder += Guid.NewGuid().ToString() + "_" + damakebaViewModel.DamakebaPhoto.FileName;

                    damakebaViewModel.DamakebaPhotoUrl = "/" + folder;

                    string serverFolder = Path.Combine(_env.WebRootPath, folder);

                    await damakebaViewModel.DamakebaPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                Damakeba damakeba = new Damakeba
                {
                    Published = DateTime.Now,
                    Document = Document.Yes,
                    UserName = User.Identity.Name,
                    DamakebaPhotoUrl = damakebaViewModel.DamakebaPhotoUrl,
                    Title = damakebaViewModel.Title,
                    Jishebi = damakebaViewModel.Jishebi,
                    Sex = damakebaViewModel.Sex,
                    City = damakebaViewModel.City,
                    Age = damakebaViewModel.Age,
                    Description = damakebaViewModel.Description,
                    EmployeName = damakebaViewModel.EmployeName,
                    PhoneNumber = damakebaViewModel.PhoneNumber,
                };
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
            return View(_damakebaNoDoucument.GetAllProduct(damakebaNoDocument).OrderByDescending(e=>e.Published));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_damakebaNoDoucument.GetProductById(id));
        }
        [Authorize]
        public IActionResult Remove(int id)
        {
            var findUser = User.Identity.Name;
            var findProduct = _damakebaNoDoucument.GetProductById(id);
            if (findUser == findProduct.UserName)
            {
                _damakebaNoDoucument.RemoveProduct(findProduct);
                _damakebaNoDoucument.SaveChange();
                return RedirectToAction("UserProfile", "Account");
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findUser = User.Identity.Name;
            var findProduct = _damakebaNoDoucument.GetProductById(id);
            if (findUser == findProduct.UserName)
            {
                DamakebaViewModel damakebaViewModel = new DamakebaViewModel()
                {
                    Age = findProduct.Age,
                    City = findProduct.City,
                    Description = findProduct.Description,
                    Document = findProduct.Document,
                    EmployeName = findProduct.EmployeName,
                    Jishebi = findProduct.Jishebi,
                    PhoneNumber = findProduct.PhoneNumber,
                    Published = findProduct.Published,
                    Sex = findProduct.Sex,
                    Title = findProduct.Title,
                    UserName = findProduct.UserName
                };
                damakebaViewModel.DamakebaPhotoUrl = findProduct.DamakebaPhotoUrl;
                return View(damakebaViewModel);
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Damakeba damakeba,int id)
        {
            if (ModelState.IsValid)
            {
                var product = _damakebaNoDoucument.GetProductById(id);
                product.Title = damakeba.Title;
                product.Sex = damakeba.Sex;
                product.Jishebi = damakeba.Jishebi;
                product.City = damakeba.City;
                product.Age = damakeba.Age;
                product.Description = damakeba.Description;
                product.EmployeName = damakeba.EmployeName;
                product.PhoneNumber = damakeba.PhoneNumber;
                if (damakeba.DamakebaPhotoUrl == null)
                {
                    damakeba.DamakebaPhotoUrl = product.DamakebaPhotoUrl;
                }
                else
                {
                    product.DamakebaPhotoUrl = damakeba.DamakebaPhotoUrl;
                }
                damakeba.UserName = product.UserName;
                product.Document = damakeba.Document;
                damakeba.Published = product.Published;
                _damakebaNoDoucument.SaveChange();
                return RedirectToAction("UserProfile","Account");
            }
            return View();
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
                damakeba.Document = Document.No;
                _damakebaNoDoucument.CreateProduct(damakeba);
                _damakebaNoDoucument.SaveChange();
                return RedirectToAction("Details",new { id = id });
            }
            return View();
        }
    }
}
