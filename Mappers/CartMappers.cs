using storeapi.Dtos.Cart;
using storeapi.Models;

namespace storeapi.Mappers;

public static class CartMappers
{
    public static CartDto ToCartDto(this Cart cart)
    {
        return new CartDto
        {
            Id = cart.Id,
            Items = cart.CartItems.Select(i=> new CartItemDto
            {
                Id = i.Id,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                ProductName = i.Product!.Name,
                Price = i.UnitPrice
            }).ToList()
        };
    }
}