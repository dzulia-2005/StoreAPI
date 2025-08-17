using Microsoft.AspNetCore.Mvc;
using storeapi.Dtos.Cart;
using storeapi.Interface;
using storeapi.Mappers;

namespace storeapi.Controller;
[ApiController]
[Route("api/order")]
public class OrderController:ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid Id)
    {
        var order = await _orderRepository.GetByIdAsync(Id);
        return Ok(order);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var order = await _orderRepository.GetAllAsync();
        return Ok(order);
    }

    [HttpDelete("delete/{Id:guid}")]
    public async Task<IActionResult> DeleteOrderAsync([FromRoute] Guid Id)
    {
        var order = await _orderRepository.DeleteAsync(Id);
        return Ok(order);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto dto)
    {
        var order = dto.ToOrderFromCreate();
        order.ToTalAmount = order.Items.Sum(i => i.UnitPrice * i.Quantity);
        var created = await _orderRepository.AddAsync(order);
        return CreatedAtAction(nameof(GetOrderById), new { Id = created.Id }, created);
    }

    [HttpPut("update/{Id:guid}")]
    public async Task<IActionResult> UpdateOrderAsync([FromRoute] Guid Id,CreateOrderDto dto)
    {
        var order = await _orderRepository.GetByIdAsync(Id);
        if (order==null)
        {
            return NotFound();
        }

        order.PaymentMethod = dto.PaymentMethod;
        order.Currency = dto.Currency;
        order.ShippingAddress = dto.ShippingAddress;
        order.UpdateAt = DateTime.UtcNow;

        await _orderRepository.UpdateAsync(order);
        return NoContent();
    }
    
}