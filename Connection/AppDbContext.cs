using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Products.Model;
using Users.Model;

namespace Connection
{   

    public class AppDbContext : DbContext      
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = ; //Connection string here
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<User> Users {get; set;}
        public DbSet<Product> Products {get; set;}


    }

}