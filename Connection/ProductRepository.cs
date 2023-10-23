using Microsoft.AspNetCore.Http.HttpResults;
using Products.Model;
using Auth;

namespace Connection;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context = new AppDbContext();
    public void Add(Product product)
    {   
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProduct(Guid productId)
    {
        var product =  _context.Products.Find(productId);
        return product;
    }

    public void RemoveProduct(Guid productId)
    {
        var product = _context.Products.Find(productId);
        
        if(product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }

    public void UpdateProduct(Guid productId, string? name = null, string? description = null, decimal? price = null, string? imagePath = null)
    {
        var product = _context.Products.Find(productId);
        if(product != null)
        {   
            if(! string.IsNullOrEmpty(name))
            {
                product.Name = name;
            }
            
            if(description != null)
            {
                product.Description = description;
            }

            if(! string.IsNullOrEmpty(imagePath))
            {
                product.Image = imagePath;
            }

            if(price != null)
            {
                product.Price = price;
            }

            _context.Products.Update(product);
            _context.SaveChanges();
        }

    }
}
