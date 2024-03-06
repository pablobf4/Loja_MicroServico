using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.IdentityServerAPI.Model.Context
{ 
    public class Context : IdentityDbContext<ApplicationUser>
	{
		protected readonly IConfiguration Configuration;
		public Context(IConfiguration configuration) { Configuration = configuration; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("IdentityDatabase"));
		}
	}
}
