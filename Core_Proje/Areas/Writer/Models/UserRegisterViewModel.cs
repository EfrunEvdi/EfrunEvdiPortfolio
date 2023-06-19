using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen görsel urlsini giriniz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen mailinizi giriniz.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifre tekrarını giriniz.")]
        [Compare("Password", ErrorMessage = "Girdiğinizi şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
