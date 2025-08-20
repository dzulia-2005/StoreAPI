namespace storeapi.Dtos.Cart;

public class CartItemDto
{
    public Guid Id { get; set; }           
    public Guid ProductId { get; set; }    
    public string ProductName { get; set; } = default!;  
    public decimal Price { get; set; }    
    public int Quantity { get; set; } 
}