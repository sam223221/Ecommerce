using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Plugin.MySQL
{
    public class MySQLDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Adjust this connection string to your Raspberry Pi's IP and database details
            optionsBuilder.UseMySql(
                "Server=192.168.1.45;Port=3306;Database=SemesterProject3;User ID=Tables;Password=Tables;",
                new MySqlServerVersion(new Version(10, 4, 32)) // Adjust version as necessary
            );

        }
    }

}
