namespace InventorySystemApi.Models

public class InventoryMovement
{
    public Guid InventoryMovementId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public InventoryMovementType Type { get; set; }
    public string Observation { get; set;}

    public virtual Product Product { get; set; }
}

public enum InventoryMovementType
{
    Entry,
    Exit
}
