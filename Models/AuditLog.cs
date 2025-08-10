namespace storeapi.Models;

public class AuditLog
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public string Action { get; set; }
    public string? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
}