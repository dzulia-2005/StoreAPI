using Microsoft.AspNetCore.Mvc;
using storeapi.Dtos.Cart;
using storeapi.Extension;
using storeapi.Interface;
using storeapi.Mappers;
using storeapi.Models;

namespace storeapi.Controller;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpPost("add-item")]
    public async Task<IActionResult> AddItem([FromBody] AddCartItemDto dto)
    {
        var UserId = User.GetUserId();
        await _cartRepository.AddCartItemAsync(UserId, dto.ProductId,dto.Quantity);
        var cart = await _cartRepository.GetCartByUserIdAsync(UserId);
        return Ok(cart?.ToCartDto());
    }

    [HttpGet("get-item")]
    public async Task<IActionResult> GetCart()
    {
        var userId = User.GetUserId();
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        return Ok(cart?.ToCartDto());
    }

    [HttpDelete("remove-item/{productId}")]
    public async Task<IActionResult> RemoveItem([FromRoute] Guid productId)
    {
        var remove = await _cartRepository.RemoveCartItemAsync(productId);
        if (!remove)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("clear-cart/{userId:guid}")]
    public async Task<IActionResult> ClearCart([FromRoute] Guid userId)
    {
        var result = await _cartRepository.ClearCartAsync(userId);
        if (!result)
        {
            return NotFound("cart not found");
        }

        return NoContent();
    }
    
    
    
    
}