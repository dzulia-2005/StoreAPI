namespace storeapi.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public decimal ToTalAmount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; } = "Pending";
    public string PaymentMethod { get; set; } = default!;
    public string ShippingAddress { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; }

    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public Payment Payment { get; set; }

}