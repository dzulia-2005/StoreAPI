namespace storeapi.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public Guid? ParentId { get; set; }
    public Category? ParentCategory { get; set; }

    public List<Category> SubCategories { get; set; } = new List<Category>();
    public List<Product> Products { get; set; } = new List<Product>();
}