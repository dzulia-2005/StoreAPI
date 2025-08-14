using Microsoft.EntityFrameworkCore;
using storeapi.Data;
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
}