using Microsoft.AspNetCore.Mvc;
using storeapi.Dtos.Category;
using storeapi.Interface;
using storeapi.Models;

namespace storeapi.Controller;
[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("categories/{Id:guid}")]
    public async Task<IActionResult> GetCategories([FromRoute] Guid Id)
    {
        var categories = await _categoryRepository.GetCategoriesAsync(Id);
        return Ok(categories);
    }

    [HttpPost("categories/create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        var category = _categoryRepository.AddCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetCategories), new { Id = category.Id }, category);
    }

    [HttpPut("categories/update/{Id:guid}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid Id, UpdateCategoryDto categoryDto)
    {
        var category = await _categoryRepository.UpdateCategoryAsync(Id, categoryDto);
        if (category == null)
        {
            return NotFound("category not found");
        }

        return Ok(category);
    }

    [HttpDelete("categories/delete/{Id:guid}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid Id)
    {
        var category = await _categoryRepository.DeleteCategoryAsync(Id);
        if (category == null)
        {
            return NotFound("category not found");
        }

        return Ok(category);
    }
}