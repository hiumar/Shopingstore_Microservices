using Mano.Services.Coupan.Model;
using Microsoft.EntityFrameworkCore;

namespace Mano.Services.Coupan.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                CoupanId = 1,
                CoupanCode = "1002",
                CoupanDisCount = 12,
                MinAmount = 3

            }) ;
            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                CoupanId=2,
                CoupanCode = "1005",
                CoupanDisCount = 50,
                MinAmount = 10

            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                CoupanId=3,
                CoupanCode = "1007",
                CoupanDisCount = 30,
                MinAmount = 8

            });
        }

        public DbSet<Coupon> coupans { get; set; }
    }
}
