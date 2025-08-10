namespace storeapi.Models;

public class ProductImage
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public string Url { get; set; }
    public bool IsPrimary { get; set; }
}