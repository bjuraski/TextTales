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

    public async Task<Category> InsertCategoryAsync(Category category)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var result = await dbContext
            .Categories
            .AddAsync(category);

        await dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Category?> UpdateCategoryAsync(Category category)
    {
        var categoryToUpdate = await GetCategoryByIdAsync(category.Id);

        if (categoryToUpdate is null)
        {
            return null;
        }

        await using var dbContext = _dbContextFactory.CreateDbContext();

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.DisplayOrder = category.DisplayOrder;

        dbContext.Categories.Update(categoryToUpdate);

        await dbContext.SaveChangesAsync();

        return categoryToUpdate;
    }

    public async Task<Category?> DeleteCategoryAsync(long id)
    {
        var categoryToDelete = await GetCategoryByIdAsync(id);

        if (categoryToDelete is null)
        {
            return null;
        }

        await using var dbContext = _dbContextFactory.CreateDbContext();

        var result = dbContext
            .Categories
            .Remove(categoryToDelete);

        await dbContext.SaveChangesAsync();

        return result.Entity;
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

    public async Task<bool> ValidateCategoryName(long? id, string name)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var nameExists = await dbContext
            .Categories
            .AnyAsync(c => (!id.HasValue || c.Id != id) && c.Name == name);

        return !nameExists;

    }

    public async Task<bool> ValidateCategoryDisplayOrder(long? id, int displayOrder)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var displayOrderExists = await dbContext
            .Categories
            .AnyAsync(c => (!id.HasValue || c.Id != id) && c.DisplayOrder == displayOrder);

        return !displayOrderExists;
    }
}
