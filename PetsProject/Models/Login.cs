using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class Login
    {
        [Display(Name ="ელ-ფოსტა")]
        [Required, EmailAddress]
        public string Email { get; set; }
        [Display(Name ="პაროლი")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
