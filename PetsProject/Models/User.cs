
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class User
    {
        [Required(ErrorMessage ="სახელის ჩაწერა აუცილებელია")]
        [Display(Name ="სახელი")]
        public string UserName { get; set; }
        [Display(Name ="ელ-ფოსტა")]
        [Required(ErrorMessage ="ელ-ფოსტის მითითება სავალდებულოა"),EmailAddress]
        public string Email { get; set; }
        [Display(Name ="პაროლი")]
        [Required(ErrorMessage =("პაროლის ჩაწერა აუცილებელია"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int VetCount { get; set; }
        [Required(ErrorMessage = "სქესის არჩევა აუცილებელია")]
        [Display(Name = "სქესი")]
        public int? UserGender { get; set; }
    }
}
