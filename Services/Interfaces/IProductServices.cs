public interface IProductServices
{
    Task<List<Product>?> Get();
    Task Add(Product product);
    Task Delete(int productId);
}