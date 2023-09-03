using TextTales.Api.Entities;

namespace TextTales.Api.Services;

public interface ICategoryRepositoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task<Category?> GetCategoryByIdAsync(long id);
}
