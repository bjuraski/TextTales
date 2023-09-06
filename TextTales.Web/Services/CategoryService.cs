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

    public bool ValidateCategoryName(long? id, string name)
    {
        var response = Task.Run(async () => await _httpClient.GetFromJsonAsync<bool>($"api/categories/validate-name?id={id}&name={name}"));
        var result = response.GetAwaiter().GetResult();

        return result;
    }

    public bool ValidateCategoryDisplayOrder(long? id, int displayOrder)
    {
        var response = Task.Run(async () => await _httpClient.GetFromJsonAsync<bool>($"api/categories/validate-display-order?id={id}&displayOrder={displayOrder}"));
        var result = response.GetAwaiter().GetResult();

        return result;
    }
}
