using InventorySystemApi.Models;
using InventorySystemApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemApi.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    protected IProductService _productService;
    public readonly ILogger<ProductController> _logger;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_productService.Get());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Get");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        try
        {
            _productService.Save(product);
            return Ok(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Post");
            return StatusCode(500, "Internal Server Error");
        }
    }

}


