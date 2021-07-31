using Microsoft.AspNetCore.Http;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.ViewModels
{
    public class PetRegistrationViewModel
    {
        [Required(ErrorMessage = "სათაურის შევსება სავალდებულოა")]
        [MaxLength(15, ErrorMessage = ("სათაურის არ უნდა აღემატებოდეს 15 სიმბოლოს"))]
        public string Title { get; set; }
        [Required(ErrorMessage = "საკონტაქტო სახელის შევსება სავალდებულოა")]
        [MaxLength(15, ErrorMessage = "საკონტაქტო სახელი არ უნდა აღემატებოდეს 15 სიმბოლოს")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "მობილურის ნომრის შევსება სავალდებულოა")]
        [MaxLength(9, ErrorMessage = ("ციფრთა რაოდენობა აღემატება 9-ს,გადაამოწმეთ შეყვანილი ინფორმაცია"))]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "ფასის მითითება სავალდებულოა,თუ არ გსურთ ფასის მითითება ველი შეავსეთ 0-ით")]
        public int? Price { get; set; }
        [MaxLength(300, ErrorMessage = ("აღწერა არ უნდა აღემატებოდეს 300 სიმბოლოს"))]
        public string Subject { get; set; }
        [Required(ErrorMessage = ("ასაკის მითითება სავალდებულოა"))]
        public int? Age { get; set; }
        [Required(ErrorMessage = "სქესის არჩევა სავალდებულოა")]
        public Sex? Sex { get; set; }
        [Required(ErrorMessage = "ჯიშის არჩევა სავალდებულოა")]
        public Jishebi? Jishebi { get; set; }
        [Required(ErrorMessage = "ქალაქის არჩევა სავალდებულოა")]
        public City? City { get; set; }
        public string PetPhotoUrl { get; set; }
        public string UserName { get; internal set; }
        public IFormFile PetPhoto { get; set; }
    }
}
