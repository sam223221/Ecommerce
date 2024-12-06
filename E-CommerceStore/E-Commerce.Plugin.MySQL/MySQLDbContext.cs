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
                "Server=webtechs3.cxga4esmo1mt.eu-north-1.rds.amazonaws.com;Port=3306;Database=webtechs3;User ID=admin;Password=WebTech3;",
                new MySqlServerVersion(new Version(8, 4, 3)),
                options => options.EnableRetryOnFailure() // Enable retry on failure
                             .MigrationsAssembly("E-Commerce.Plugin.MySQL")
            );
        }

    }

}