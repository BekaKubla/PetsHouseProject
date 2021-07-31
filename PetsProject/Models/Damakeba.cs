using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class Damakeba
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "ველის შევსება სავალდებულოა")]
        public string Title { get; set; }
        [Required(ErrorMessage = "აირჩიეთ ჯიში")]
        public Jishebi? Jishebi { get; set; }
        [Required(ErrorMessage = "აირჩიეთ სქესი")]
        public Sex? Sex { get; set; }
        [Required(ErrorMessage ="აირჩიეთ ქალაქი")]
        public City? City { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ ასაკი")]
        [RegularExpression("^[0-9][0-9]?$", ErrorMessage = "Please enter a valid age")]
        public int? Age { get; set; }
        public string Document { get; set; }
        [Required(ErrorMessage = "ველის შევსება სავალდებულოა")]
        [MaxLength(300,ErrorMessage ="აღწერა უნდა შეიცავდეს მაქსიმუმ 300 სიმბოლოს")]
        public string Description { get; set; }
        public DateTime Published { get; set; }
        [Required(ErrorMessage ="ველის შევსება სავალდებულოა")]
        [MaxLength(30,ErrorMessage ="სახელი უნდა შეიცავდეს მაქსიმუმ 30 სიმბოლოს")]
        public string EmployeName { get; set; }
        [Required(ErrorMessage ="ველის შევსება სავალდებულოა")]
        [MaxLength(9,ErrorMessage ="გადაამოწმეთ მობულირის ნომერი")]
        public string PhoneNumber { get; set; }
    }
}
