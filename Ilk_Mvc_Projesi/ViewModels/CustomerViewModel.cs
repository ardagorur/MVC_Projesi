using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.ViewModels
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "Şirket Adı alanı gereklidir")]
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }
        [Display(Name = "Yetkili Adı")]
        public string ContactName { get; set; }
        [Display(Name = "Yetkili Ünvanı")]
        public string ContactTitle { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }
        [Display(Name = "Bölge")]
        public string Region { get; set; }
        [Display(Name = "Posta Kodu")]
        public string PostalCode { get; set; }
        [Display(Name = "Ülke")]
        public string Country { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }
        [Display(Name = "Fax Numarası")]
        public string Fax { get; set; }
    }
}
