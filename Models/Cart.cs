namespace storeapi.Models;

public class Cart
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }

    public List<Cart> CartItems { get; set; } = new List<Cart>();
}