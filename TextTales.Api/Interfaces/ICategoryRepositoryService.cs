using TextTales.Models;

namespace TextTales.Api.Interfaces;

public interface ICategoryRepositoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task<Category?> GetCategoryByIdAsync(long id);

    Task<Category> InsertCategoryAsync(Category category);

    Task<Category?> UpdateCategoryAsync(Category category);

    Task<Category?> DeleteCategoryAsync(long id);

    Task<bool> ValidateCategoryName(long? id, string name);

    Task<bool> ValidateCategoryDisplayOrder(long? id, int displayOrder);
}
