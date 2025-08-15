using storeapi.Dtos.Products;
using storeapi.Models;

namespace storeapi.Interface;

public interface IProductRepository
{
    Task<List<Product?>> GetAllProducts();
    Task<Product?> GetProductByIdAsync(Guid Id);
    Task<Product?> AddProductAsync(CreateProductDto productdto,Guid UserId);
    Task<Product?> UpdateProductAsync(Guid Id, UpdateProductDto productDto);
    Task<Product?> DeleteProductAsync(Guid Id);
}