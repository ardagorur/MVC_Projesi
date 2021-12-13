using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Kategori Adı alanı gereklidir")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }
        public int? CategoryId { get; set; }
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        public decimal? UnitPrice { get; set; }

    }
}
