using storeapi.Dtos.Products;
using storeapi.Models;

namespace storeapi.Mappers;

public static class ProductMappers
{
    public static ProductDto toProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Slug = product.Slug,
            Currency = product.Currency,
            StockQuantity = product.StockQuantity,
            IsActive = product.IsActive,
            Price = product.Price,
            Description = product.Description,
            UserId = product.UserId
        };
    }

    public static Product ToProductFromUpdate(this UpdateProductDto productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Slug = productDto.Slug,
            Currency = productDto.Currency,
            StockQuantity = productDto.StockQuantity,
            IsActive = productDto.IsActive,
            Price = productDto.Price,
            Description = productDto.Description,
            UserId = productDto.UserId
        };
    }
}