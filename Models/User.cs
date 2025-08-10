namespace storeapi.Models;

public class User
{
    public string FullName { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();
    public List<Cart> Carts { get; set; } = new List<Cart>();
}