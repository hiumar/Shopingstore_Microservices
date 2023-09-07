using Mango.Service.ShoppingCartAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.ShoppingCartAPi.Data
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
