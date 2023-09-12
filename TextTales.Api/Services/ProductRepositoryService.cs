using Microsoft.EntityFrameworkCore;
using TextTales.Api.Data;
using TextTales.Api.Interfaces;
using TextTales.Models;

namespace TextTales.Api.Services;

public class ProductRepositoryService : IProductRepositoryService
{
    private readonly ApplicationDbContextFactory _dbContextFactory;

    public ProductRepositoryService(ApplicationDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var products = await dbContext
            .Products
            .Include(p => p.Category)
            .ToListAsync();

        return products;
    }

    public async Task<Product> InsertProductAsync(Product product)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var result = await dbContext
            .Products
            .AddAsync(product);

        await dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        var productToUpdate = await GetProductByIdAsync(product.Id);

        if (productToUpdate is null)
        {
            return null;
        }

        await using var dbContext = _dbContextFactory.CreateDbContext();

        productToUpdate.Title = product.Title;
        productToUpdate.Author = product.Author;
        productToUpdate.Description = product.Description;
        productToUpdate.InternationalStandardBookNumber = product.InternationalStandardBookNumber;
        productToUpdate.Price = product.Price;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.Image = product.Image;

        dbContext.Products.Update(productToUpdate);

        await dbContext.SaveChangesAsync();

        return productToUpdate;
    }

    public async Task<Product?> DeleteProductAsync(long id)
    {
        var productToDelete = await GetProductByIdAsync(id);

        if (productToDelete is null)
        {
            return null;
        }

        await using var dbContext = _dbContextFactory.CreateDbContext();

        var result = dbContext
            .Products
            .Remove(productToDelete);

        await dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Product?> GetProductByIdAsync(long id)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var product = await dbContext
            .Products
            .Where(p => p.Id == id)
            .SingleOrDefaultAsync();

        return product;
    }

    public async Task<bool> ValidateProductTitle(long? id, string title)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var titleExists = await dbContext
            .Products
            .AnyAsync(p => (!id.HasValue || p.Id != id) && p.Title.ToLower() == title.ToLower());

        return !titleExists;
    }

    public async Task<bool> ValidateProductISBN(long? id, string bookNumber)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        var bookNumberExists = await dbContext
            .Products
            .AnyAsync(p => (!id.HasValue || p.Id != id) && p.InternationalStandardBookNumber.ToLower() == bookNumber.ToLower());

        return !bookNumberExists;
    }
}
