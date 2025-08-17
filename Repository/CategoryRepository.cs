using Microsoft.EntityFrameworkCore;
using storeapi.Data;
using storeapi.Dtos.Category;
using storeapi.Interface;
using storeapi.Mappers;
using storeapi.Models;

namespace storeapi.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> GetCategoriesAsync(Guid Id)
    {
        return await _context.Categories.FindAsync(Id);
    }

    public async Task<Category?> AddCategoryAsync(CreateCategoryDto categoryDto)
    {
        var existCategory =
            await _context.Categories.AnyAsync(c => c.Name == categoryDto.Name || c.Slug == categoryDto.Slug);

        if (!existCategory)
        {
            throw new Exception("category with same name or slug is already exist");
        }

        var createCategory = categoryDto.ToCategoryFromCreate();
        _context.Categories.Add(createCategory);
        await _context.SaveChangesAsync();
        return createCategory;
    }

    public async Task<Category?> UpdateCategoryAsync(Guid Id,UpdateCategoryDto categoryDto)
    {
        var existCategory = await _context.Categories.FindAsync(Id);
        if (existCategory == null)
        {
            return null;
        }

        var updateCategory = categoryDto.ToCategoryFromUpdate();
        existCategory.Name = updateCategory.Name;
        existCategory.Slug = updateCategory.Slug;

        await _context.SaveChangesAsync();
        return existCategory;
    }

   
}