using TextTales.Models;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>?>("api/categories");

        return categories;
    }

    public async Task<Category?> GetCategory(int id)
    {
        var category = await _httpClient.GetFromJsonAsync<Category?>($"api/categories/{id}");

        return category;
    }
}
