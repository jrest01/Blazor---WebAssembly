using System.Net.Http.Json;
using System.Text.Json;

class CategoryServices : ICategoryServices
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions options;

    public CategoryServices(HttpClient client)
    {
        httpClient = client;
        // options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    }

    public async Task<List<Category>?> Get()
    {
        var response = await httpClient.GetAsync("v1/categories");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return await JsonSerializer.DeserializeAsync<List<Category>>(await response.Content.ReadAsStreamAsync());
    }

    public async Task Add(Category category)
    {
        var response = await httpClient.PostAsync("v1/categories", JsonContent.Create(category));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task Delete(int categoryId)
    {
        var response = await httpClient.DeleteAsync($"v1/categories{categoryId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}

