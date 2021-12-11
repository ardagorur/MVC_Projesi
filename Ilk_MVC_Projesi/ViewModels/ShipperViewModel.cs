using System;
using System.ComponentModel.DataAnnotations;

namespace Ilk_MVC_Projesi.VewModels
{
    public class ShipperViewModel
    {
        [Required(ErrorMessage = "Şirket Adı alanı gereklidir")]
        [Display(Name = "Şirket Adı")]
        public string CompanyName { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }
        public int ShipperId { get; set; }
    }
}
