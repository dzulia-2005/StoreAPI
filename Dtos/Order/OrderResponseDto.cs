namespace storeapi.Dtos.Cart;

public class OrderResponseDto
{
    public Guid Id { get; set; }
    public decimal ToTalAmount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; } = "Pending";
    public string PaymentMethod { get; set; } = default!;
    public string ShippingAddress { get; set; } = default!;
    public DateTime CreateAt { get; set; }
    List<OrderItemResponseDto> Items { get; set; } = new List<OrderItemResponseDto>();
    
}