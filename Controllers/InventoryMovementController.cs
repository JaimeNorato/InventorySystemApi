using InventorySystemApi.Models;
using InventorySystemApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemApi.Controllers;

[Route("api/[controller]")]
public class InventoryMovementController : ControllerBase
{
    protected IInventoryMovementService _inventoryMovementService;
    public readonly ILogger<InventoryMovementController> _logger;

    public InventoryMovementController(IInventoryMovementService inventoryMovementService, ILogger<InventoryMovementController> logger)
    {
        _inventoryMovementService = inventoryMovementService;
        _logger = logger;
    }

    [HttpGet("{productId}")]
    public IActionResult Get(Guid productId)
    {
        try
        {
            return Ok(_inventoryMovementService.Get(productId));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Get");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] InventoryMovement inventoryMovement)
    {
        try
        {
            _inventoryMovementService.Save(inventoryMovement);
            return Ok(inventoryMovement);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Post");
            return StatusCode(500, "Internal Server Error");
        }
    }

}