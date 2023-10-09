using Products.Model;

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

    // public Product GetProduct(Guid productId)
    // {
    //     var product =  _context.Products.Find(productId);
    //     return product;
    // }
}
