using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class JobVacancy
    {
        public int Id { get; set; }
        [Display(Name ="დასახელება")]
        [Required(ErrorMessage ="შევსება სავალდებულოა")]
        [MaxLength(50,ErrorMessage ="სათაურის მაქსიმალური ზომა : 50 სიმბოლო")]
        public string JobName { get; set; }
        [Display(Name ="კანდიდატის ასაკი (X წლიდან)")]
        [Required(ErrorMessage ="შევსება სავალდებულოა")]
        [Range(17,99,ErrorMessage ="ასაკი უნდა იყოს 17 წლიდან 99 წლამდე")]
        public int? Age { get; set; }
        [Display(Name ="საკონტაქტო ნომერი")]
        [Required(ErrorMessage ="ველის შევსელბა სავალდებულოა")]
        [MaxLength(9,ErrorMessage ="ნომერი არასწორია,გადაამოწმეთ შეყვანილი ინფორმაცია (xxx-xx-xx-xx)")]
        public string PhoneNumber { get; set; }
        [Display(Name ="სქესი")]
        [Required(ErrorMessage ="აირჩიეთ სქესი")]
        public PersonSex? PersonSex { get; set; }
        [Display(Name ="სამუშაო დღეები კვირაში")]
        [Required(ErrorMessage ="აირჩიეთ სამუშაო დღეები კვირაში")]
        public Week? Week { get; set; }
        [Display(Name ="სამუშაო საათები დღეში")]
        [Required(ErrorMessage ="აირჩიეთ სამუშაო საათები დღეში")]
        public StartTime? StartTime { get; set; }
        [Display(Name = "სამუშაო საათები დღეში")]
        [Required(ErrorMessage = "აირჩიეთ სამუშაო საათები დღეში")]
        public EndTime? EndTime { get; set; }
        [Display(Name ="სამუშაო ადგილი")]
        [Required(ErrorMessage ="აირჩიეთ სამუშაო ადგილი")]
        public City? City { get; set; }
        [Display(Name = "მოვალეობა")]
        [Required(ErrorMessage = "მოვალეობის შევსება სავალდებულოა")]
        [MaxLength(22,ErrorMessage = "მოვალეობა უნდა შედგებოდეს მაქსიმუმ 20 სიმბოლოსგან")]
        public string JobDescription { get; set; }
        [Display(Name ="ვაკანსიის სრული აღწერა")]
        [Required(ErrorMessage ="ვაკანსიის სრული აღწერა სავალდებულოა")]
        [MaxLength(300,ErrorMessage ="აღწერა უნდა შედგებოდეს მაქსიმუმ 300 სიმბოლოსგან")]
        public string FullDescription { get; set; }
        [Display(Name ="ხელფასი")]
        public int? Sallary { get; set; }
        public DateTime Published { get; set; }
        [Display(Name ="საკონტაქტო სახელი")]
        [Required(ErrorMessage = "სახელის შევსება სავალდებულოა")]
        [MaxLength(20)]
        public string EmployerName { get; set; }
        public string UserName { get; set; }
    }
    public enum PersonSex
    {
        მდედრობითი,
        მამრობითი,
        [Display(Name ="არ აქვს მნიშვნელობა")]
        nebismieri
    }
    public enum Week
    {
        [Display(Name = "1")]
        one =1,
        [Display(Name = "2")]
        two =2,
        [Display(Name = "3")]
        three =3,
        [Display(Name = "4")]
        four =4,
        [Display(Name = "5")]
        five = 5,
        [Display(Name = "6")]
        six = 6,
        [Display(Name = "7")]
        seven = 7,
    }
    public enum StartTime
    {
        [Display(Name ="01:00")]
        one=1,
        [Display(Name = "02:00")]
        two =2,
        [Display(Name = "03:00")]
        three =3,
        [Display(Name = "04:00")]
        four =4,
        [Display(Name = "05:00")]
        five =5,
        [Display(Name = "06:00")]
        six =6,
        [Display(Name = "07:00")]
        seven =7,
        [Display(Name = "08:00")]
        eight =8,
        [Display(Name = "09:00")]
        nine =9,
        [Display(Name = "10:00")]
        ten =10,
        [Display(Name = "11:00")]
        eleve =11,
        [Display(Name = "12:00")]
        twelve =12,
        [Display(Name = "13:00")]
        thirteen =13,
        [Display(Name = "14:00")]
        Fourteen =14,
        [Display(Name = "15:00")]
        fiveteen =15,
        [Display(Name = "16:00")]
        sixteen =16,
        [Display(Name = "17:00")]
        seventeen =17,
        [Display(Name = "18:00")]
        eighteen =18,
        [Display(Name = "19:00")]
        nineteen =19,
        [Display(Name = "20:00")]
        twenty =20,
        [Display(Name = "21:00")]
        twentyone =21,
        [Display(Name = "22:00")]
        twentytwo =22,
        [Display(Name = "23:00")]
        twentythree =23,
        [Display(Name = "24:00")]
        twentyfour =24
    }
    public enum EndTime
    {
        [Display(Name = "01:00")]
        one = 1,
        [Display(Name = "02:00")]
        two = 2,
        [Display(Name = "03:00")]
        three = 3,
        [Display(Name = "04:00")]
        four = 4,
        [Display(Name = "05:00")]
        five = 5,
        [Display(Name = "06:00")]
        six = 6,
        [Display(Name = "07:00")]
        seven = 7,
        [Display(Name = "08:00")]
        eight = 8,
        [Display(Name = "09:00")]
        nine = 9,
        [Display(Name = "10:00")]
        ten = 10,
        [Display(Name = "11:00")]
        eleve = 11,
        [Display(Name = "12:00")]
        twelve = 12,
        [Display(Name = "13:00")]
        thirteen = 13,
        [Display(Name = "14:00")]
        Fourteen = 14,
        [Display(Name = "15:00")]
        fiveteen = 15,
        [Display(Name = "16:00")]
        sixteen = 16,
        [Display(Name = "17:00")]
        seventeen = 17,
        [Display(Name = "18:00")]
        eighteen = 18,
        [Display(Name = "19:00")]
        nineteen = 19,
        [Display(Name = "20:00")]
        twenty = 20,
        [Display(Name = "21:00")]
        twentyone = 21,
        [Display(Name = "22:00")]
        twentytwo = 22,
        [Display(Name = "23:00")]
        twentythree = 23,
        [Display(Name = "24:00")]
        twentyfour = 24
    }
}
