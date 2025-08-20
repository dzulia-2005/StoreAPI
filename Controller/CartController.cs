using Microsoft.AspNetCore.Mvc;
using storeapi.Dtos.Cart;
using storeapi.Extension;
using storeapi.Interface;
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
        var item = await _cartRepository.AddCartItemAsync(UserId, dto.);
    }
}