using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MyMessagePro.Models
{
    public class UserRegisterViewModel
    {
        
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string username { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string mail { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string password { get; set; }
        [Compare("password",ErrorMessage ="şifreler uyumlu değil kontrol ediniz")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string confirmPassword { get; set; }
    }
}
