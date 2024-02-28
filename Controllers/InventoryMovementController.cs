using InventorySystemApi.Models;
using InventorySystemApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

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
            _logger.LogInformation("1 InventoryMovement: {0}", inventoryMovement.InventoryMovementId);
            _logger.LogInformation("2 InventoryMovement: {0}", inventoryMovement.Observation);
            _logger.LogInformation("3 InventoryMovement: {0}", inventoryMovement.ProductId);
            _logger.LogInformation("4 InventoryMovement: {0}", inventoryMovement.Quantity);

            DateTime date = DateTime.Now;
            inventoryMovement.Date = date.ToUniversalTime();

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