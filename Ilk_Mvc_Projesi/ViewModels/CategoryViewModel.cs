using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ilk_Mvc_Projesi.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Kategori Adı alanı gereklidir")]
        [StringLength(15,ErrorMessage = "Kategori Adı alanı en fazla 15 karakter olabilir")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public int ProductCount { get; set; }
    }
}
