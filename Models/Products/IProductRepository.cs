namespace Products.Model;
public interface IProductRepository
{
    void Add(Product product);

    void RemoveProduct(Guid productId);

    List<Product> GetAllProducts();

    Product? GetProduct(Guid productId);

    void UpdateProduct(Guid productId, string? name = null, string? description = null, double? price = null, string? imagePath = null);


}
