using storeapi.Models;

namespace storeapi.Dtos.Cart;

public class CreateOrderDto
{
    public Guid UserId { get; set; }
    public string Currency { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public string ShippingAddress { get; set; } = default!;
    public List<CreateOrderItemDto> Items { get; set; } = new List<CreateOrderItemDto>();
}