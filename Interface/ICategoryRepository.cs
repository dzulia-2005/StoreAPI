using storeapi.Dtos.Category;
using storeapi.Models;

namespace storeapi.Interface;

public interface ICategoryRepository
{
    Task<Category?> GetCategoriesAsync(Guid Id);
    Task<Category?> AddCategoryAsync(CreateCategoryDto categoryDto);

}