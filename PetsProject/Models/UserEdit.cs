using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class UserEdit
    {
        [Required,EmailAddress]
        [Display(Name ="ელ-ფოსტა")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="პაროლი")]
        public string Password { get; set; }

        public UserEdit() { }
        public UserEdit(AppUser appUser)
        {
            Email = appUser.Email;
            Password = appUser.PasswordHash;
        }
    }
}
