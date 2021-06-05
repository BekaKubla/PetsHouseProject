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
        avstraliuri_nagazi,
        [Display(Name = "ამერიკული აკიტა")]
        amerikuli_akita,
        [Display(Name = "ამერიკული ბულდოგი")]
        amerikuli_buldogi,
        [Display(Name = "ამერიკული ბული")]
        amerikuli_buli,
        [Display(Name = "ამერიკული კოკერ-სპანიელი")]
        amerikuli_koker_spanieli,
        [Display(Name = "ამერიკული სტეფორდშირტერიერი")]
        amerikuli_stefordshirterieri,
        [Display(Name = "ამერიკული დოგი")]
        argentinuli_dogi,
        [Display(Name = "აღმოსავლურ-ევროპული ნაგაზი")]
        agmosavluri_evropuli_nagazi,
        [Display(Name = "აღმოსავლურ-ციმბირული ლაიკა")]
        agmosavluri_cimbiruli_laika,
        [Display(Name = "ბელგიური-ნაგაზი (მალინუა)")]
        belgiuri_nagazi_malinua,
        [Display(Name = "ბერნი ზენენჰუდი")]
        bernis_zenenhudi,
        [Display(Name = "ბიგლი")]
        bigli,
        [Display(Name = "ბორდერ-კოლი")]
        border_koli,
        [Display(Name = "ბორდოული დოგი")]
        bordouli_dogi,
        [Display(Name = "ბოქსიორი")]
        boqsiori,
        [Display(Name = "ბრაზილიური ფილა")]
        braziluri_fila,
        [Display(Name = "პრეტონული ესპანიული")]
        bretonuli_espaniuli,
        [Display(Name = "ბულმასტიფი")]
        bulmastifi,
        [Display(Name = "ბულტერიერი")]
        bulterieri,
        [Display(Name = "გერმანული-დოგი")]
        germanuli_dogi,
        [Display(Name = "გერმანული-იაგდტერიერი")]
        germanuli_iagdterieri,
        [Display(Name = "გერმანული-ნაგაზი")]
        germanuli_nagazi,
        [Display(Name = "გრძელბალნიანი კოლი")]
        grdzelbalniani_koli,
        [Display(Name = "დალმატინელი")]
        dalmatineli,
        [Display(Name = "დასავლეთ ციმბირული ლაიკა")]
        dasavlet_cimbiruli_laika,
        [Display(Name = "დობერმანი")]
        dobermani,
        [Display(Name = "დრახტარი")]
        dratxari,
        [Display(Name = "ერდელტერიერი")]
        erdelterieri,
        [Display(Name = "ესპანული დოგი")]
        espanuri_dogi,
        [Display(Name = "ვეიმარანერი")]
        veimaraneri,
        [Display(Name = "თეთრი შვეიცარული ნაგაზი")]
        tetri_shveicaruli_nagazi,
        [Display(Name = "იაპონური აკიტა")]
        iaponuri_akita,
        [Display(Name = "ინგლისურ-რუსული მდევარი")]
        inglisur_rusuli_mdevari,
        [Display(Name = "ინგლისური ბულდოგი")]
        inglisuri_buldogi,
        [Display(Name = "ინგლისური სეტერი")]
        inglisuri_seteri,
        [Display(Name = "იორკშირ ტერიერი")]
        iorkshir_terieri,
        [Display(Name = "ირლანდიური მგელთამგუდავი")]
        irlandiuri_mgeltamgudavi,
        [Display(Name = "ირლანდიური სეტერი")]
        irlandiuri_seteri,
        [Display(Name = "კავკასური ნაგაზი")]
        kavkasiuri_nagazi,
        [Display(Name = "კანე კორსო")]
        kane_korso,
        [Display(Name = "კოკერ სპანიელი")]
        koker_spanieli,
        [Display(Name = "კურცჰაარი")]
        kurchaari,
        [Display(Name = "ლაბრადორ რეტრივერი")]
        labrador_retriveri,
        [Display(Name = "ლევრეტკა")]
        levretka,
        [Display(Name = "მალამუტი")]
        malamuti,
        [Display(Name = "მალტეზე")]
        malteze,
        [Display(Name = "მალტიპუ")]
        maltipu,
        [Display(Name = "მასტინო")]
        mastino,
        [Display(Name = "მეტისი")]
        metisi,
        [Display(Name = "მექსიკური შიშველი ძაღლი")]
        meqsikuri_shishveli_dzagli,
        [Display(Name = "მოპსი")]
        mopsi,
        [Display(Name = "ოქროს რეტრივერი")]
        oqros_retriveri,
        [Display(Name = "პეკინესი")]
        pekinesi,
        [Display(Name = "პიტ ბულტერიერი")]
        pit_bulterieri,
        [Display(Name = "პომერანიული შპიცი")]
        pomeraniuli_shpici,
        [Display(Name = "პუდელი")]
        pudeli,
        [Display(Name = "როდეზიული_რიჯბექი")]
        rodeziuli_rijbeqi,
        [Display(Name = "როტვეილერი")]
        rotveileri,
        [Display(Name = "რუსულ-ევროპული ლაიკა")]
        rusul_evropuli_laika,
        [Display(Name = "რუსული ტოი ტერიერი")]
        rusuli_toi_terieri,
        [Display(Name = "სალუკი")]
        saluki,
        [Display(Name = "სამოედური ლაიკა")]
        samoeduro_laika,
        [Display(Name = "სამხრეთ-რუსული ნაგაზი")]
        samxtret_rusuli_nagazi,
        [Display(Name = "სენბერნარი")]
        senbernari,
        [Display(Name = "სკოჩ ტერიერი")]
        skoch_terieri,
        [Display(Name = "სტეფორშირ ბულტერიერი")]
        stefordshir_bulterieri,
        [Display(Name = "ტაილანდური რიჯბექი")]
        tailanduri_rijbeqi,
        [Display(Name = "ტაქსა")]
        taqsa,
        [Display(Name = "ტიბეტური მასტიფი")]
        tibeturi_mastifi,
        [Display(Name = "ინგლისური ვიჯლა")]
        ingruli_vijla,
        [Display(Name = "ფოქტერიერი")]
        foqterieri,
        [Display(Name = "ფრანგული ბულდოგი")]
        franguli_buldogi,
        [Display(Name = "ქართული ნაგაზი")]
        qartuli_nagazi,
        [Display(Name = "შარ-პეი")]
        shar_pei,
        [Display(Name = "ში-ცუ")]
        shi_cu,
        [Display(Name = "შიბა")]
        shiba,
        [Display(Name = "შოტლანდიური ნაგაზი")]
        shotlandiuri_nagazi,
        [Display(Name = "შოტლანდირუ სეტერი (გორდონი)")]
        shotlandiuri_seteri_gordoni,
        [Display(Name = "შუააზიური ნაგაზი")]
        shuaaziuri_nagazi,
        [Display(Name = "ჩაუ-ჩაუ")]
        chau_chau,
        [Display(Name = "ჩინური ქოჩორა ძაღლი")]
        chinuri_qochora_dzagli,
        [Display(Name = "ჩიხუახუა")]
        chixuaxua,
        [Display(Name = "ცვერგპიჩერი")]
        cvergpicheri,
        [Display(Name = "ცვერგშნაუცერი")]
        cvergshnauceri,
        [Display(Name = "ციმბირული ჰასკი")]
        cimbiruli_haski,
        [Display(Name = "ჯეკ რასელ ტერიერი")]
        jek_rasel_terieri,
        [Display(Name = "სხვა")]
        sxva
    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
