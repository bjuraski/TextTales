using TextTales.Models;

namespace TextTales.Web.Interfaces;

public interface IProductService : IValidateFieldService
{
    Task<IEnumerable<Product>?> GetProducts();

    Task<Product?> GetProduct(long id);

    Task<bool> CreateProduct(Product product);

    Task<bool> UpdateProduct(long id, Product product);

    Task<bool> DeleteProduct(long id);

    Task<bool> ProductOfCategoryExists(long categoryId);
}
