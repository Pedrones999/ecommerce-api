using Microsoft.EntityFrameworkCore;
using Products.Model;
using Users.Model;

namespace Users.Connection
{
    public class UserConnectionDb : DbContext      
    {
        public UserConnectionDb(DbContextOptions<UserConnectionDb>options) 
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");
         
            modelBuilder.Entity<User>()
                .Property(c => c.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<User>()
                .Property(c => c.Name)
                .HasColumnName("Name");

            modelBuilder.Entity<User>()
                .Property(c => c.Email)
                .HasColumnName("Email");

            modelBuilder.Entity<User>()
                .Property(c => c.UserPassword)
                .HasColumnName("UserPassword");

            modelBuilder.Entity<User>()
                .Property(c => c.Role)
                .HasColumnName("RoleID");

        }
    }

}