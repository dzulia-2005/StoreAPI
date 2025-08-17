using storeapi.Dtos.Cart;
using storeapi.Models;

namespace storeapi.Mappers;

public static class OrderMappers
{
    public static Order ToOrderFromCreate(this CreateOrderDto orderDto)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            UserId = orderDto.UserId,
            Currency = orderDto.Currency,
            PaymentMethod = orderDto.PaymentMethod,
            ShippingAddress = orderDto.ShippingAddress,
            CreatedAt = DateTime.UtcNow,
            Status = "Pending",
            Items = orderDto.Items.Select(i=>new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
    }
}