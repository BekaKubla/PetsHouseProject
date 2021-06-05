using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="ველის შევსება სავალდებულოა")]
        [MaxLength(15,ErrorMessage ="ველის შესავსებად გამოყენეთ არაუმეტეს 15 სიმბოლო")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "ველის შევსება სავალდებულოა")]
        [EmailAddress(ErrorMessage ="ელ-ფოსტა არასწორია")]
        public string Email { get; set; }
        [Required(ErrorMessage = "ველის შევსება სავალდებულოა")]
        [MaxLength(30, ErrorMessage = "ველის შესავსებად გამოყენეთ არაუმეტეს 30 სიმბოლო")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ველის შევსება სავალდებულოა")]
        [MaxLength(300, ErrorMessage = "ველის შესავსებად გამოყენეთ არაუმეტეს 300 სიმბოლო")]
        public string Subject { get; set; }
    }
}
