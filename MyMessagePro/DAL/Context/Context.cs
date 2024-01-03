using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyMessagePro.DAL.Entities;

namespace MyMessagePro.DAL.Context
{
	public class Context:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-2PU1K7L\\SQLEXPRESS; initial catalog=myMessageDB; integrated security=true;");
		}
        
        public DbSet<UMessage> UMessages { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        
    }
}
