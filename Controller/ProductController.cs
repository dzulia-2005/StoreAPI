using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storeapi.Dtos.Products;
using storeapi.Interface;
using storeapi.Mappers;

namespace storeapi.Controller;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductController(IProductRepository productRepository,IHttpContextAccessor httpContextAccessor)
    {
        _productRepository = productRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepository.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{Id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] Guid Id)
    {
        var product = await _productRepository.GetProductByIdAsync(Id);
        return Ok(product.toProductDto());
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        try
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim==null)
            {
                return Unauthorized();
            }

            var userId = Guid.Parse(userIdClaim);
            var createdProduct = await _productRepository.AddProductAsync(productDto,userId);
            return CreatedAtAction(nameof(GetById), new { Id = createdProduct.Id }, createdProduct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("update/{Id:guid}")]
    [Authorize]
    public async Task<IActionResult> EditProduct([FromRoute] Guid Id,[FromBody] UpdateProductDto productDto)
    {
        var product = await _productRepository.UpdateProductAsync(Id, productDto);
        if (product == null)
        {
            return NotFound("product not found");
        }

        return Ok(product.toProductDto());
    }

    [HttpDelete("delete/{Id:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid Id)
    {
        var product = await _productRepository.DeleteProductAsync(Id);
        if (product==null)
        {
            return NotFound("product not found");
        }
        return NoContent();
    }
} 