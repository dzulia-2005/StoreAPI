namespace storeapi.Dtos.Cart;

public class OrderItemResponseDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}