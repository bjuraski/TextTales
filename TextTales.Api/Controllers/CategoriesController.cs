using Microsoft.AspNetCore.Mvc;
using TextTales.Api.Services;
using TextTales.Models;

namespace TextTales.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepositoryService _categoryRepositoryService;

    public CategoriesController(ICategoryRepositoryService categoryRepositoryService)
    {
        _categoryRepositoryService = categoryRepositoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        try
        {
            var categories = await _categoryRepositoryService.GetCategoriesAsync();

            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while retrieving data from database: {ex.Message}");
        }
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Category>> GetCategory(long id)
    {
        try
        {
            var category = await _categoryRepositoryService.GetCategoryByIdAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while retrieving data from database: {ex.Message}");
        }
    }
}
