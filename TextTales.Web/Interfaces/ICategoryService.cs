using TextTales.Models;

namespace TextTales.Web.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>?> GetCategories();

    Task<Category?> GetCategory(long id);

    Task<bool> CreateCategory(Category category);

    Task<bool> UpdateCategory(long id, Category category);

    bool ValidateCategoryName(string name);

    bool ValidateCategoryDisplayOrder(int displayOrder);
}
