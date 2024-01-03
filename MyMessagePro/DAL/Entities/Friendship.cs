using System.ComponentModel.DataAnnotations;

namespace MyMessagePro.DAL.Entities
{
	public class Friendship
	{
		[Key]
		public int friendshipID { get; set; }
        [EmailAddress(ErrorMessage ="Geçerli Mail Giriniz")]
        public string friendSenderUsername { get; set; }
		[EmailAddress(ErrorMessage = "Geçerli Mail Giriniz")]
		public string friendReceiverUsername { get; set; }
        public DateTime friendDate { get; set; }
        public bool status { get; set; }
        
    }
}
