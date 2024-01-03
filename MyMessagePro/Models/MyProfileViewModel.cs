namespace MyMessagePro.Models
{
    public class MyProfileViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string mail { get; set; }
        public string imageUrl { get; set; }
        public IFormFile image { get; set; }        
        public string city { get; set; }
       
    }
}
