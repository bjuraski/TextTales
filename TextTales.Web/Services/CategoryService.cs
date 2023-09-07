using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Services;

public class CategoryService : ValidateFieldService, ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }

    public override string ControllerName { get; } = "Categories";

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>?>("api/categories");

        return categories;
    }

    public async Task<Category?> GetCategory(long id)
    {
        var category = await _httpClient.GetFromJsonAsync<Category?>($"api/categories/{id}");

        return category;
    }

    public async Task<bool> CreateCategory(Category category)
    {
        var response = await _httpClient.PostAsJsonAsync("api/categories", category);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategory(long id, Category category)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", category);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategory(long id)
    {
        var response = await _httpClient.DeleteFromJsonAsync<Category>($"api/categories/{id}");

        return response is not null;
    }
}
