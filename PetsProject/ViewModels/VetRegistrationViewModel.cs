using Microsoft.AspNetCore.Http;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.ViewModels
{
    public class VetRegistrationViewModel
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="სახელის ველის შევსება სავალდებულოა")]
        [MinLength(2, ErrorMessage = "სახელი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "გვარის ველის შევსება სავალდებულოა")]
        [MinLength(1, ErrorMessage = "გვარი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="ქალაქის არჩევა აუცილებელია")]
        public City? City { get; set; }
        [MinLength(1, ErrorMessage = "კომპანიის სახელი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "ასაკის ველის შევსება სავალდებულოა")]
        [Range(18, 99, ErrorMessage = "ასაკი უნდა იყოს 18 ზე მეტი და 99 ზე ნაკლები")]
        public int? Age { get; set; }
        [MinLength(1, ErrorMessage = "პოზიციის სახელი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string Position { get; set; }
        [Required(ErrorMessage = "თქვენს შესახებ ველის შევსება სავალდებულოა")]
        [MaxLength(300, ErrorMessage = "ჩაწერილი ინფორმაციო არ უნდა აღემატებოდეს 300 სიტყვას")]
        public string About { get; set; }
        [Required(ErrorMessage = "მობილურის ველის შევსება სავალდებულოა")]
        [MaxLength(9, ErrorMessage = "მობილურის ნომერი არასწორადაა შეყვანილი")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "მისამართის ველის შევსება სავალდებულოა")]
        [MaxLength(60, ErrorMessage = "მისამართი არ უნდა აღემატებოდეს 60 სიმბოლოს")]
        public string Adress { get; set; }
        public IFormFile VetPhoto { get; set; }
        public string VetImageUrl { get; set; }
    }
}
