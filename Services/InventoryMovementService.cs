using InventorySystemApi.Contexts;
using InventorySystemApi.Models;

namespace InventorySystemApi.Services;

public class InventoryMovementService : IInventoryMovementService
{
    ProductContext context;

    public InventoryMovementService(ProductContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<InventoryMovement> Get(Guid productId)
    {
        return context.InventoryMovements.Where(im => im.ProductId == productId);
    }

    public async Task Save(InventoryMovement inventoryMovement)
    {
        context.Add(inventoryMovement);
        await context.SaveChangesAsync();
    }
}

public interface IInventoryMovementService
{
    IEnumerable<InventoryMovement> Get(Guid productId);
    Task Save(InventoryMovement inventoryMovement);
}