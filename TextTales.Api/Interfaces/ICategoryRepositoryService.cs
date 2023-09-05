using TextTales.Models;

namespace TextTales.Api.Interfaces;

public interface ICategoryRepositoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task<Category?> GetCategoryByIdAsync(long id);

    Task<Category> InsertCategoryAsync(Category category);

    Task<Category?> UpdateCategoryAsync(Category category);

    Task<bool> ValidateCategoryName(string name);

    Task<bool> ValidateCategoryDisplayOrder(int displayOrder);
}
