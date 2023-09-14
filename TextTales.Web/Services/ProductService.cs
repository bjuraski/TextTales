using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Services;

public class ProductService : ValidateFieldService, IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }

    public override string ControllerName => "Products";

    public async Task<IEnumerable<Product>?> GetProducts()
    {
        var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>?>("api/products");

        return products;
    }

    public async Task<Product?> GetProduct(long id)
    {
        var product = await _httpClient.GetFromJsonAsync<Product?>($"api/products/{id}");

        return product;
    }

    public async Task<bool> CreateProduct(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/products", product);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProduct(long id, Product product)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}", product);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProduct(long id)
    {
        var response = await _httpClient.DeleteFromJsonAsync<Product>($"api/products/{id}");

        return response is not null;
    }

    public async Task<bool> ProductOfCategoryExists(long categoryId)
    {
        var response = await _httpClient.GetFromJsonAsync<bool>($"api/products/product-of-category-exists?categoryId={categoryId}");

        return response;
    }
}
