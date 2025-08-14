using Microsoft.AspNetCore.Mvc;
using storeapi.Dtos.Products;
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

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        try
        {
            var createdProduct = await _productRepository.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { Id = createdProduct.Id }, createdProduct);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}