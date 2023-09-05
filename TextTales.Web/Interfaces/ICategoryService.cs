using TextTales.Models;

namespace TextTales.Web.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>?> GetCategories();

    Task<Category?> GetCategory(int id);

    Task<bool> CreateCategory(Category category);
}
