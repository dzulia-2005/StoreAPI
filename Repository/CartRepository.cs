using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using storeapi.Data;
using storeapi.Interface;
using storeapi.Models;

namespace storeapi.Repository;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cart?> GetCartByUserIdAsync(Guid UserId)
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.UserId == UserId);
    }

    public async Task<CartItem?> AddCartItemAsync(Guid UserId, Guid ProductId, int quantity)
    {
        var cart = await GetCartByUserIdAsync(UserId) ?? new Cart() {UserId = UserId , CartItems = new List<CartItem>()};
        if (cart.Id == Guid.Empty)
        {
            _context.Carts.AddAsync(cart);
        }

        var exist = cart.CartItems.FirstOrDefault(i => i.ProductId == ProductId);
        if (exist != null)
        {
            throw new Exception("cartitem already exist,use UpdateCartItem to change quantity");
        }

        var product = await _context.Products.FindAsync(ProductId);
        if (product==null)
        {
            throw new Exception("product not found");
        }

        var item = new CartItem
        {
            CartId = cart.Id,
            ProductId = ProductId,
            Quantity = quantity,
            UnitPrice = product.Price
            
        };

        _context.CartItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<CartItem?> UpdateCartItemAsync(Guid CartItemId, int quantity)
    {
        var cart = await _context.CartItems.FindAsync(CartItemId);
        if (cart==null)
        {
            return null;
        }

        cart.Quantity = quantity;
        await _context.SaveChangesAsync();
        return cart;
    }

    public async Task<bool> RemoveCartItemAsync(Guid CartItemId)
    {
        var cart = await _context.CartItems.FindAsync(CartItemId);
        _context.CartItems.Remove(cart);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> ClearCartAsync(Guid userId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();
        return true;
    }
    
}