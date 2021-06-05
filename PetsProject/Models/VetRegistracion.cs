using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class VetRegistracion
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "სახელი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string Name { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "გვარი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "ქალაქის არჩევა აუცილებელია")]
        public City? City { get; set; }
        [MinLength(1, ErrorMessage = "კომპანიის სახელი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string CompanyName { get; set; }
        [Required]
        [Range(18,99,ErrorMessage ="ასაკი უნდა იყოს 18 ზე მეტი და 99 ზე ნაკლები")]
        public int? Age { get; set; }
        [MinLength(1, ErrorMessage = "პოზიციის სახელი უნდა იყოს 1 სიმბოლოზე მეტი")]
        public string Position { get; set; }
        [Required]
        [MaxLength(300,ErrorMessage ="ჩაწერილი ინფორმაციო არ უნდა აღემატებოდეს 300 სიტყვას")]
        public string About { get; set; }
        [Required]
        [MaxLength(9,ErrorMessage ="მობილურის ნომერი არასწორადაა შეყვანილი")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required]
        [MaxLength(60,ErrorMessage ="მისამართი არ უნდა აღემატებოდეს 60 სიმბოლოს")]
        public string Adress { get; set; }
        public string VetphotoUrl { get; set; }
        public DateTime RegistrationDateTime { get; set; }

    }
    public enum City
    {
        აბაშა,
        ამბროლაური,
        ახალქალაქი,
        ახალციხე,
        ახმეტა,
        ბათუმი,
        ბაღდათი,
        ბოლნისი,
        ბორჯომი,
        გარდაბანი,
        გორი,
        გურჯაანი,
        დედოფლისწყარო,
        დმანისი,
        დუშეთი,
        ვალე,
        ვანი,
        ზესტაფონი,
        ზუგდიდი,
        თბილისი,
        თეთრიწყარო,
        თელავი,
        თერჯოლა,
        კასპი,
        ლაგოდეხი,
        ლანჩხუთი,
        მარნეული,
        მარტვილი,
        მცხეთა,
        ნინოწმინდა,
        ოზურგეთი,
        ონი,
        რუსთავი,
        საგარეჯო,
        სამტრედია,
        საჩხერე,
        სენაკი,
        სიღნაღი,
        ტყიბული,
        ფოთი,
        ქარელი,
        ქობულეთი,
        ქუთაისი,
        ყვარელი,
        ჩხოროწყუ,
        ცაგერი,
        წალენჯიხა,
        წალკა,
        წნორი,
        წყალტუბო,
        ჭიათურა,
        ხაშური,
        ხობი,
        ხონი,
        ჯვარი
    }
}
