using Microsoft.AspNetCore.Identity;

namespace MyMessagePro.DAL.Entities
{
    public class AppUser:IdentityUser<int>
    {       
        public string? city { get; set; }       
        public string? cender { get; set; }
        public string? imageUrl { get; set; }
    }
}
