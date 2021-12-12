using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.ViewModels
{
    public class ShipperViewModel
    {
        public int ShipperID { get; set; }
        [Required(ErrorMessage = "Firma Adı alanı gereklidir")]
        [StringLength(15, ErrorMessage = "Firma Adı alanı en fazla 15 karakter olabilir")]
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }
        [Display(Name = "Teelefon Numarası")]
        public string Phone { get; set; }
    }
}
