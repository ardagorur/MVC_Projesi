using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_MVC_Projesi.VewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage ="Kategori adı alanı gereklidir")]
        [StringLength(15,ErrorMessage="Kategori Ado alanı en fazla 15 karekter olabilir.")]
        [Display(Name = "Kategori Name")]
        public string CategoryName { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
    }
}
