using Microsoft.EntityFrameworkCore;
using Auth;
using Products.Model;
using Users.Model;

namespace Connection
{   

    public class AppDbContext : DbContext      
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Product> Products {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = Keys.Connection;
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }
    }

}