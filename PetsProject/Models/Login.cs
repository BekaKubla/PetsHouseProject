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
        [Required (ErrorMessage = "ელ-ფოსტის შეყვანა აუცილებელია"), EmailAddress(ErrorMessage ="ელ-ფოსტა არასწორადაა შეყვანილი ")]
        public string Email { get; set; }
        [Display(Name ="პაროლი")]
        [Required(ErrorMessage ="პაროლის ჩაწერა აუცილებელია")]
        [DataType(DataType.Password,ErrorMessage =("გადაამოწმეთ შეყვანილი ინფორმაცია"))]
        public string Password { get; set; }
    }
}
