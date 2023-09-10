using Microsoft.AspNetCore.Mvc;
using TextTales.Api.Interfaces;
using TextTales.Models;

namespace TextTales.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepositoryService _productRepositoryService;

    public ProductsController(IProductRepositoryService productRepositoryService)
    {
        _productRepositoryService = productRepositoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        try
        {
            var products = await _productRepositoryService.GetProductsAsync();

            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while retrieving data from database: {ex.Message}");
        }
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Product>> GetProduct(long id)
    {
        try
        {
            var product = await _productRepositoryService.GetProductByIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while retrieving data from database: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        try
        {
            if (product is null)
            {
                return BadRequest();
            }

            var createdProduct = await _productRepositoryService.InsertProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { createdProduct.Id }, createdProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while inserting new product record in database: {ex.Message}");
        }
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<Product?>> UpdateProduct(long id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest("Product Id mismatch");
        }

        try
        {
            var updatedProduct = await _productRepositoryService.UpdateProductAsync(product);

            if (updatedProduct is null)
            {
                return NotFound($"Product with Id = {id} not found");
            }

            return Ok(updatedProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while updating product record in database: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(long id)
    {
        if (id == default)
        {
            return BadRequest("Product Id can't be default value");
        }

        try
        {
            var deletedProduct = await _productRepositoryService.DeleteProductAsync(id);

            if (deletedProduct is null)
            {
                return NotFound($"Product with Id = {id} not found");
            }

            return Ok(deletedProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while deleting product record from database: {ex.Message}");
        }
    }

    [HttpGet("validate-title")]
    public async Task<ActionResult<bool>> ValidateProductTitle([FromQuery] long? id, [FromQuery] string? title)
    {
        try
        {
            if (string.IsNullOrEmpty(title))
            {
                return Ok(true);
            }

            var isTitleValid = await _productRepositoryService.ValidateProductTitle(id, title);

            return Ok(isTitleValid);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred while validating product title: {ex.Message}");
        }
    }

    [HttpGet("validate-international-standard-book-number")]
    public async Task<ActionResult<bool>> ValidateProductISBN([FromQuery] long? id, [FromQuery(Name = "international-standard-book-number")] string? bookNumber)
    {
        try
        {
            if (string.IsNullOrEmpty(bookNumber))
            {
                return Ok(true);
            }

            var isISBNValid = await _productRepositoryService.ValidateProductISBN(id, bookNumber);

            return Ok(isISBNValid);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred while validating product ISBN: {ex.Message}");
        }
    }
}
