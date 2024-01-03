using System.ComponentModel.DataAnnotations;

namespace MyMessagePro.Models
{
	public class UserLoginViewModel
	{
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        public string username { get; set; }
		[Required(ErrorMessage = "Şifre Boş Geçilemez")]
		public string password { get; set; }
    }
}
