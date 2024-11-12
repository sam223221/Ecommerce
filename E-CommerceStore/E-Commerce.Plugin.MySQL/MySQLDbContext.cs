using ECommerce.CoreEntityBusiness;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Plugin.MySQL
{
    public class MySQLDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<shopingCart> ShopingCarts { get; set; }

        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=autorack.proxy.rlwy.net;Port=33999;Database=railway;User ID=root;Password=SHaHNCasnuRCimHHYaGhJmcfFBqYXkPl;",
                new MySqlServerVersion(new Version(10, 4, 32)),
                options => options.EnableRetryOnFailure() // Enable retry on failure
                             .MigrationsAssembly("E-Commerce.Plugin.MySQL")
            );
        }

    }

}
