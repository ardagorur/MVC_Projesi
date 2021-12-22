using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="İsim alanı gereklidir")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim alanı gereklidir")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-Posta alanı gereklidir")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [Display(Name = "Şifre")]
        [StringLength(50)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
