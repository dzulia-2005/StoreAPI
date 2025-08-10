namespace storeapi.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "GEL";
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}