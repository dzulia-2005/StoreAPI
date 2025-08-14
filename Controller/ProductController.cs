using Microsoft.AspNetCore.Mvc;
using storeapi.Interface;

namespace storeapi.Controller;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepository.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid Id)
    {
        var product = await _productRepository.GetProductByIdAsync(Id);
        return Ok(product);
    }
    
    
}