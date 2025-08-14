using storeapi.Models;

namespace storeapi.Interface;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
}