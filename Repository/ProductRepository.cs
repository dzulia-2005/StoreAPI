using Microsoft.EntityFrameworkCore;
using storeapi.Data;
using storeapi.Dtos.Products;
using storeapi.Interface;
using storeapi.Models;

namespace storeapi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(Guid Id)
    {
        return await _context.Products.FindAsync(Id);
    }

    public async Task<Product?> AddProductAsync(CreateProductDto productDto)
    {
        var user = await _context.Products.FindAsync(productDto.UserId);
        if (user==null)
        {
            throw new Exception("user not found");
        }

        var product = new Product
        {
            Name = productDto.Name,
            Slug = productDto.Slug,
            Description = productDto.Description,
            Price = productDto.Price,
            Currency = productDto.Currency,
            StockQuantity = productDto.StockQuantity,
            IsActive = productDto.IsActive,
            UserId = productDto.UserId,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }
}