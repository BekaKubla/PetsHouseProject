using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class User
    {
        [Required]
        [Display(Name ="სახელი")]
        public string UserName { get; set; }
        [Display(Name ="ელ-ფოსტა")]
        [Required,EmailAddress]
        public string Email { get; set; }
        [Display(Name ="პაროლი")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int VetCount { get; set; }
    }
}
