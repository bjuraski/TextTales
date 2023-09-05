using Microsoft.EntityFrameworkCore;
using TextTales.Api.Data;
using TextTales.Api.Interfaces;
using TextTales.Models;

namespace TextTales.Api.Services;

public class CategoryRepositoryService : ICategoryRepositoryService
{
    private readonly ApplicationDbContextFactory _dbContextFactory;

    public CategoryRepositoryService(ApplicationDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var categories = await dbContext
            .Categories
            .ToListAsync();

        return categories;
    }

    public async Task<Category?> GetCategoryByIdAsync(long id)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var category = await dbContext
            .Categories
            .Where(c => c.Id == id)
            .SingleOrDefaultAsync();

        return category;
    }
}
