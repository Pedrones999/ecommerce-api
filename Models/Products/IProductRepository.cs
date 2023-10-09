namespace Products.Model;
public interface IProductRepository
{
    void Add(Product product);

    // void Remove(Product product);

    List<Product> GetAllProducts();

    //Product GetProduct(Guid productId);
}
