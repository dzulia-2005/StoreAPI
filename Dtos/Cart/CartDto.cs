namespace storeapi.Dtos.Cart;

public class CartDto
{
    public Guid Id { get; set; }
    public List<CartItemDto> Items { get; set; } = new();  
    
    public decimal Total => Items.Sum(i => i.Price * i.Quantity);
}