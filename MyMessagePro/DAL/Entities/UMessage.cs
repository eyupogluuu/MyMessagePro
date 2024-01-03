using System.ComponentModel.DataAnnotations;

namespace MyMessagePro.DAL.Entities
{
	public class UMessage
	{
		[Key]
        public int messageID { get; set; }
		[Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
		[StringLength(150)]
        public string? subject { get; set; }
		[Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
		[StringLength(2500)]
		public string? content { get; set; }
        public DateTime date { get; set; }
		public string? senderUsername { get; set; }
		public string? receiverUsername { get; set; }
		public bool draft { get; set; }
		public bool status { get; set; }
        
    }
}
