using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    
    
    public async Task<Product?> AddProductAsync(CreateProductDto productDto,Guid UserId)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Slug = productDto.Slug,
            Description = productDto.Description,
            Price = productDto.Price,
            Currency = productDto.Currency,
            StockQuantity = productDto.StockQuantity,
            IsActive = productDto.IsActive,
            UserId = UserId,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }
    
    
    public async Task<Product?> UpdateProductAsync(Guid Id,UpdateProductDto productDto)
    {
        var existingProduct = await _context.Products.FindAsync(Id);
        if (existingProduct==null)
        {
            return null;
        }

        existingProduct.Name = productDto.Name;
        existingProduct.StockQuantity = productDto.StockQuantity;
        existingProduct.Price = productDto.Price;
        existingProduct.Currency = productDto.Currency;
        existingProduct.Description = productDto.Description;
        existingProduct.IsActive = productDto.IsActive;
        existingProduct.UserId = productDto.UserId;
        existingProduct.Slug = productDto.Slug;

        await _context.SaveChangesAsync();
        return existingProduct;

    }

    
    public async Task<Product?> DeleteProductAsync(Guid Id)
    {
        var product = await _context.Products.FindAsync(Id);
        if (product==null)
        {
            return null;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}