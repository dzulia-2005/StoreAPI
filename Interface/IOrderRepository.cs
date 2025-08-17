using storeapi.Models;

namespace storeapi.Interface;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid Id);
    Task<Order?> AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task<Order?> DeleteAsync(Guid Id);
    Task<List<Order>> GetAllAsync();
}