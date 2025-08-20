using storeapi.Models;

namespace storeapi.Interface;

public interface ICartRepository
{
    Task<Cart?> GetCartByUserIdAsync(Guid UserId);
    Task<CartItem?> AddCartItemAsync(Guid UserId,Guid ProductId,int quantity);
    Task<CartItem?> UpdateCartItemAsync(Guid CartItemId, decimal quantity);
    Task<bool> RemoveCartItemAsync(Guid CartItemId);
    Task<bool> ClearCartAsync(Guid userId);

}