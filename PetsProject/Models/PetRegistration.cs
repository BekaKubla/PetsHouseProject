using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PetsProject.Models
{
    public class PetRegistration
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public int? Price { get; set; }
        public string Subject { get; set; }
        public int? Age { get; set; }
        public Sex? Sex { get; set; }
        public Jishebi? Jishebi { get; set; }
        public City? City { get; set; }
        public string PetPhotoUrl { get; set; }
        public string UserName { get;set; }
        public DateTime PetRegistrationDateTime { get; set; }
    }
    public  enum Sex
    {
        ძუ,
        ხვადი
    }
    public enum Jishebi
    {
        [Display(Name ="ავსტრალიური ნაგაზი")]
        ავსტრალიური_ნაგაზი,
        [Display(Name = "ამერიკული აკიტა")]
        ამერიკული_აკიტა,
        [Display(Name = "ამერიკული ბულდოგი")]
        ამერიკული_ბულდოგი,
        [Display(Name = "ამერიკული ბული")]
        ამერიკული_ბული,
        [Display(Name = "ამერიკული კოკერ-სპანიელი")]
        ამერიკული_კოკერ_სპანიელი,
        [Display(Name = "ამერიკული სტეფორდშირტერიერი")]
        ამერიკული_სტეფორდშირტერიერი,
        [Display(Name = "ამერიკული დოგი")]
        ამერიკული_დოგი,
        [Display(Name = "აღმოსავლურ-ევროპული ნაგაზი")]
        აღმოსავლურ_ევროპული_ნაგაზი,
        [Display(Name = "აღმოსავლურ-ციმბირული ლაიკა")]
        აღმოსავლურ_ციმბირული_ლაიკა,
        [Display(Name = "ბელგიური-ნაგაზი (მალინუა)")]
        ბელგიური_ნაგაზი_მალინუა,
        [Display(Name = "ბერნი ზენენჰუდი")]
        ბერნი_ზენენჰუდი,
        [Display(Name = "ბიგლი")]
        ბიგლი,
        [Display(Name = "ბორდერ-კოლი")]
        ბორდერ_კოლი,
        [Display(Name = "ბორდოული დოგი")]
        ბორდოული_დოგი,
        [Display(Name = "ბოქსიორი")]
        ბოქსიორი,
        [Display(Name = "ბრაზილიური ფილა")]
        ბრაზილიური_ფილა,
        [Display(Name = "პრეტონული ესპანიული")]
        პრეტონული_ესპანიული,
        [Display(Name = "ბულმასტიფი")]
        ბულმასტიფი,
        [Display(Name = "ბულტერიერი")]
        ბულტერიერი,
        [Display(Name = "გერმანული-დოგი")]
        გერმანული_დოგი,
        [Display(Name = "გერმანული-იაგდტერიერი")]
        გერმანული_იაგდტერიერი,
        [Display(Name = "გერმანული-ნაგაზი")]
        გერმანული_ნაგაზი,
        [Display(Name = "გრძელბალნიანი კოლი")]
        გრძელბალნიანი_კოლი,
        [Display(Name = "დალმატინელი")]
        დალმატინელი,
        [Display(Name = "დასავლეთ ციმბირული ლაიკა")]
        დასავლეთ_ციმბირული_ლაიკა,
        [Display(Name = "დობერმანი")]
        დობერმანი,
        [Display(Name = "დრახტარი")]
        დრახტარი,
        [Display(Name = "ერდელტერიერი")]
        ერდელტერიერი,
        [Display(Name = "ესპანული დოგი")]
        ესპანული_დოგი,
        [Display(Name = "ვეიმარანერი")]
        ვეიმარანერი,
        [Display(Name = "თეთრი შვეიცარული ნაგაზი")]
        თეთრი_შვეიცარული_ნაგაზი,
        [Display(Name = "იაპონური აკიტა")]
        იაპონური_აკიტა,
        [Display(Name = "ინგლისურ-რუსული მდევარი")]
        ინგლისურ_რუსული_მდევარი,
        [Display(Name = "ინგლისური ბულდოგი")]
        ინგლისური_ბულდოგი,
        [Display(Name = "ინგლისური სეტერი")]
        ინგლისური_სეტერი,
        [Display(Name = "იორკშირ ტერიერი")]
        იორკშირ_ტერიერი,
        [Display(Name = "ირლანდიური მგელთამგუდავი")]
        ირლანდიური_მგელთამგუდავი,
        [Display(Name = "ირლანდიური სეტერი")]
        ირლანდიური_სეტერი,
        [Display(Name = "კავკასური ნაგაზი")]
        კავკასური_ნაგაზი,
        [Display(Name = "კანე კორსო")]
        კანე_კორსო,
        [Display(Name = "კოკერ სპანიელი")]
        კოკერ_სპანიელი,
        [Display(Name = "კურცჰაარი")]
        კურცჰაარი,
        [Display(Name = "ლაბრადორ რეტრივერი")]
        ლაბრადორ_რეტრივერი,
        [Display(Name = "ლევრეტკა")]
        ლევრეტკა,
        [Display(Name = "მალამუტი")]
        მალამუტი,
        [Display(Name = "მალტეზე")]
        მალტეზე,
        [Display(Name = "მალტიპუ")]
        მალტიპუ,
        [Display(Name = "მასტინო")]
        მასტინო,
        [Display(Name = "მეტისი")]
        მეტისი,
        [Display(Name = "მექსიკური შიშველი ძაღლი")]
        მექსიკური_შიშველი_ძაღლი,
        [Display(Name = "მოპსი")]
        მოპსი,
        [Display(Name = "ოქროს რეტრივერი")]
        ოქროს_რეტრივერი,
        [Display(Name = "პეკინესი")]
        პეკინესი,
        [Display(Name = "პიტ ბულტერიერი")]
        პიტ_ბულტერიერი,
        [Display(Name = "პომერანიული შპიცი")]
        პომერანიული_შპიცი,
        [Display(Name = "პუდელი")]
        პუდელი,
        [Display(Name = "როდეზიული რიჯბექი")]
        როდეზიული_რიჯბექი,
        [Display(Name = "როტვეილერი")]
        როტვეილერი,
        [Display(Name = "რუსულ-ევროპული ლაიკა")]
        რუსულ_ევროპული_ლაიკა,
        [Display(Name = "რუსული ტოი ტერიერი")]
        რუსული_ტოი_ტერიერი,
        [Display(Name = "სალუკი")]
        სალუკი,
        [Display(Name = "სამოედური ლაიკა")]
        სამოედური_ლაიკა,
        [Display(Name = "სამხრეთ-რუსული ნაგაზი")]
        სამხრეთ_რუსული_ნაგაზი,
        [Display(Name = "სენბერნარი")]
        სენბერნარი,
        [Display(Name = "სკოჩ ტერიერი")]
        სკოჩ_ტერიერი,
        [Display(Name = "სტეფორშირ ბულტერიერი")]
        სტეფორშირ_ბულტერიერი,
        [Display(Name = "ტაილანდური რიჯბექი")]
        ტაილანდური_რიჯბექი,
        [Display(Name = "ტაქსა")]
        ტაქსა,
        [Display(Name = "ტიბეტური მასტიფი")]
        ტიბეტური_მასტიფი,
        [Display(Name = "ინგლისური ვიჯლა")]
        ინგლისური_ვიჯლა,
        [Display(Name = "ფოქტერიერი")]
        ფოქტერიერი,
        [Display(Name = "ფრანგული ბულდოგი")]
        ფრანგული_ბულდოგი,
        [Display(Name = "ქართული ნაგაზი")]
        ქართული_ნაგაზი,
        [Display(Name = "შარ-პეი")]
        შარ_პეი,
        [Display(Name = "ში-ცუ")]
        ში_ცუ,
        [Display(Name = "შიბა")]
        შიბა,
        [Display(Name = "შოტლანდიური ნაგაზი")]
        შოტლანდიური_ნაგაზი,
        [Display(Name = "შოტლანდირუ სეტერი (გორდონი)")]
        შოტლანდირუ_სეტერი_გორდონი,
        [Display(Name = "შუააზიური ნაგაზი")]
        შუააზიური_ნაგაზი,
        [Display(Name = "ჩაუ-ჩაუ")]
        ჩაუ_ჩაუ,
        [Display(Name = "ჩინური ქოჩორა ძაღლი")]
        ჩინური_ქოჩორა_ძაღლი,
        [Display(Name = "ჩიხუახუა")]
        ჩიხუახუა,
        [Display(Name = "ცვერგპიჩერი")]
        ცვერგპიჩერი,
        [Display(Name = "ცვერგშნაუცერი")]
        ცვერგშნაუცერი,
        [Display(Name = "ციმბირული ჰასკი")]
        ციმბირული_ჰასკი,
        [Display(Name = "ჯეკ რასელ ტერიერი")]
        ჯეკ_რასელ_ტერიერი,
        [Display(Name = "სხვა")]
        სხვა
    }
}
