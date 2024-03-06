
using E_Commerce.PB.CuponAPI.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.CuponAPI.Model.Context
{
	public class Context : DbContext
	{
		protected readonly IConfiguration Configuration;
		public Context(IConfiguration configuration) { Configuration = configuration; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
		}
		public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "PABLO_2022_10",
                DiscountAmount = 10
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "PABLO_2022_15",
                DiscountAmount = 15
            });
        }

    }
}
