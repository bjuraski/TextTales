using Microsoft.EntityFrameworkCore;
using TextTales.Api.Data;
using TextTales.Api.Entities;

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
}
