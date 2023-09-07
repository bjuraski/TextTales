using Microsoft.AspNetCore.Mvc;
using TextTales.Api.Interfaces;
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

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
    {
        try
        {
            if (category is null)
            {
                return BadRequest();
            }

            var createdCategory = await _categoryRepositoryService.InsertCategoryAsync(category);

            return CreatedAtAction(nameof(GetCategory), new { createdCategory.Id }, createdCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while inserting new category record in database: {ex.Message}");
        }
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<Category?>> UpdateCategory(long id, [FromBody] Category category)
    {
        if (id != category.Id)
        {
            return BadRequest("Category Id mismatch");
        }

        try
        {
            var updatedCategory = await _categoryRepositoryService.UpdateCategoryAsync(category);

            if (updatedCategory is null)
            {
                return NotFound($"Category with Id = {id} not found");
            }

            return Ok(updatedCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while updating category record in database: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Category>> DeleteCategory(long id)
    {
        if (id == default)
        {
            return BadRequest("Category Id can't be default value");
        }

        try
        {
            var deletedCategory = await _categoryRepositoryService.DeleteCategoryAsync(id);

            if (deletedCategory is null)
            {
                return NotFound($"Category with Id = {id} not found");
            }

            return Ok(deletedCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while deleting category record from database: {ex.Message}");
        }
    }

    [HttpGet("validate-name")]
    public async Task<ActionResult<bool>> ValidateCategoryName([FromQuery] long? id, [FromQuery] string? name)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
            {
                return Ok(true);
            }

            var isNameValid = await _categoryRepositoryService.ValidateCategoryName(id, name);

            return Ok(isNameValid);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred while validating category name: {ex.Message}");
        }
    }

    [HttpGet("validate-display-order")]
    public async Task<ActionResult<bool>> ValidateCategoryDisplayOrder([FromQuery] long? id, [FromQuery(Name = "display-order")] int displayOrder)
    {
        try
        {
            if (displayOrder == default)
            {
                return Ok(true);
            }

            var isDisplayOrderValid = await _categoryRepositoryService.ValidateCategoryDisplayOrder(id, displayOrder);

            return Ok(isDisplayOrderValid);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred while validating category display order: {ex.Message}");
        }
    }
}
