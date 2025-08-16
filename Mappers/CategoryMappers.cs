using storeapi.Dtos.Category;
using storeapi.Dtos.Products;
using storeapi.Models;

namespace storeapi.Mappers;

public static class CategoryMappers
{
    public static Category ToCategoryFromCreate(this CreateCategoryDto createCategoryDto)
    {
        return new Category
        {
            Name = createCategoryDto.Name,
            Slug = createCategoryDto.Slug
        };
    }

    public static Category ToCategoryFromUpdate(this UpdateCategoryDto updateCategoryDto)
    {
        return new Category
        {
            Name = updateCategoryDto.Name,
            Slug = updateCategoryDto.Slug
        };
    }
}