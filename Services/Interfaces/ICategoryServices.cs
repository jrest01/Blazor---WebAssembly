public interface ICategoryServices
{
    Task<List<Category>?> Get();
    Task Add(Category category);
    Task Delete(int categoryId);
}