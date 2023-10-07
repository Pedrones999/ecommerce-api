using Microsoft.EntityFrameworkCore;
using Products.Model;

namespace Products.Connection
{
    public class ProdConnectionDb : DbContext      
    {
        public ProdConnectionDb(DbContextOptions<ProdConnectionDb>options) 
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products");
         
            modelBuilder.Entity<Product>()
                .Property(c => c.ProductId)
                .HasColumnName("ProductId")
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Product>()
                .Property(c => c.Name)
                .HasColumnName("Name");

            modelBuilder.Entity<Product>()
                .Property(c => c.Price)
                .HasColumnName("price");

            modelBuilder.Entity<Product>()
                .Property(c => c.Description)
                .HasColumnName("Description");
        }
    }

}