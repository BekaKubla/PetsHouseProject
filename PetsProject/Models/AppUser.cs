using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class AppUser  : IdentityUser
    {
        public string Occupation { get; set; }
        [Required(ErrorMessage ="სქესის არჩევა აუცილებელია")]
        [Display(Name ="სქესი")]
        public Gender UserGender { get; set; }
        [Required(ErrorMessage = "სქესის არჩევა აუცილებელია")]
        [Display(Name = "სქესი")]
        public int GenderValue { get; set; }
        public enum Gender
        {
            მდედრობითი,
            მამრობითი
        }
    }
}
