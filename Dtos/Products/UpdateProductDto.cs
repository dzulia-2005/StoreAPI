using System.ComponentModel.DataAnnotations.Schema;

namespace storeapi.Dtos.Products;

public class UpdateProductDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string Currency { get; set; } = "GEL";
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
}