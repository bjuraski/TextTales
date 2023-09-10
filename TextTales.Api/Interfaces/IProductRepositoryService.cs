using TextTales.Models;

namespace TextTales.Api.Interfaces;

public interface IProductRepositoryService
{
    Task<IEnumerable<Product>> GetProductsAsync();

    Task<Product?> GetProductByIdAsync(long id);

    Task<Product> InsertProductAsync(Product product);

    Task<Product?> UpdateProductAsync(Product product);

    Task<Product?> DeleteProductAsync(long id);

    Task<bool> ValidateProductTitle(long? id, string title);

    Task<bool> ValidateProductISBN(long? id, string bookNumber);
}
