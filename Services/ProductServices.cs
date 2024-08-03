using System.Net.Http.Json;
using System.Runtime.Intrinsics;
using System.Text.Json;

class ProductServices : IProductServices
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions options;

    public ProductServices(HttpClient client)
    {
        httpClient = client;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }


    public async Task<List<Product>?> Get()
    {
        var response = await httpClient.GetAsync("v1/products");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync());
    }

    public async Task<Product> GetById(int productId)
    {
        var response = await httpClient.GetAsync($"v1/products/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return await JsonSerializer.DeserializeAsync<Product>(await response.Content.ReadAsStreamAsync());
    }

    public async Task Add(Product product)
    {
        var response = await httpClient.PostAsync("v1/products", JsonContent.Create(product));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task Delete(int productId)
    {
        var response = await httpClient.DeleteAsync($"v1/products/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

}