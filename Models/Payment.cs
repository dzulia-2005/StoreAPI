namespace storeapi.Models;

public class Payment
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Order Order { get; set; }

    public string Provider { get; set; } = default!;
    public string ProviderPaymentId { get; set; } = default!;
    public string Status { get; set; } = "Pending";
    public string Amount { get; set; }
    public string Currency { get; set; } = "GEL";
    
    public string? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    
}