using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeapi.Data;
using storeapi.Interface;
using storeapi.Models;

namespace storeapi.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(Guid Id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == Id);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<Order?> AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> DeleteAsync(Guid Id)
    {
        var order = await _context.Orders.FindAsync(Id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return order;
    }
}