using Microsoft.AspNetCore.Http;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.ViewModels
{
    public class PetRegistrationViewModel
    {
        public string Title { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public int Price { get; set; }
        public string Subject { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Jishebi Jishebi { get; set; }
        public City City { get; set; }
        public string PetPhotoUrl { get; set; }
        public IFormFile PetPhoto { get; set; }
    }
}
