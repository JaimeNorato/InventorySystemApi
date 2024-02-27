namespace InventorySystemApi.Models

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
}