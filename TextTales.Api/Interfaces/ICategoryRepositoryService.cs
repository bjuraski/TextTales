using TextTales.Models;

namespace TextTales.Api.Interfaces;

public interface ICategoryRepositoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task<Category?> GetCategoryByIdAsync(long id);
}
