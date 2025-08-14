using Microsoft.AspNetCore.Identity;

namespace storeapi.Models;

public class User : IdentityUser<Guid>
{
    public string Role { get; set; } = "USER";
    public DateTime CreatedAt { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();
    public List<Cart> Carts { get; set; } = new List<Cart>();
    
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}