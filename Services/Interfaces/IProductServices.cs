public interface IProductServices
{
    Task<List<Product>?> Get();
    Task<Product> GetById(int productId);
    Task Add(Product product);
    Task Delete(int productId);
}