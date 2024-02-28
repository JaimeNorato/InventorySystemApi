namespace InventorySystemApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    // private readonly IProductRepository _productRepository;

    public readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    // public ProductController(IProductRepository productRepository)
    // {
    //     _productRepository = productRepository;
    // }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    // {
    //     var products = await _productRepository.GetProducts();
    //     return Ok(products);
    // }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Product>> GetProduct(int id)
    // {
    //     var product = await _productRepository.GetProduct(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(product);
    // }

    // [HttpPost]
    // public async Task<ActionResult<Product>> CreateProduct(Product product)
    // {
    //     await _productRepository.CreateProduct(product);
    //     return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateProduct(int id, Product product)
    // {
    //     if (id != product.Id)
    //     {
    //         return BadRequest();
    //     }
    //     await _productRepository.UpdateProduct(product);
    //     return NoContent();
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteProduct(int id)
    // {
    //     var product = await _productRepository.GetProduct(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //     await _productRepository.DeleteProduct(product);
    //     return NoContent();
    // }
}

// Path: Models/Product.cs

