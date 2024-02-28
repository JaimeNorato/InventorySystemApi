namespace InventorySystemApi.Contexts;

using Microsoft.EntityFrameworkCore;
using InventorySystemApi.Models;


public class ProductContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<InventoryMovement> InventoryMovement { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(product => {
            product.ToTable("product");
            product.HasKey(p => p.ProductId);
            product.Property(p => p.Name).IsRequired().HasMaxLength(250);
            product.Property(p => p.Stock).IsRequired();
            product.HasMany(p => p.InventoryMovements).WithOne(im => im.Product).HasForeignKey(im => im.ProductId);
        });

        modelBuilder.Entity<InventoryMovement>(InventoryMovement => {
            InventoryMovement.ToTable("inventory_movement");
            InventoryMovement.HasKey(im => im.InventoryMovementId);
            InventoryMovement.Property(im => im.ProductId).IsRequired();
            InventoryMovement.Property(im => im.Quantity).IsRequired();
            InventoryMovement.Property(im => im.Date).IsRequired();
            InventoryMovement.Property(im => im.Type).IsRequired();
            InventoryMovement.Property(im => im.Observation).HasMaxLength(250);
            InventoryMovement.HasOne(im => im.Product).WithMany(p => p.InventoryMovements).HasForeignKey(im => im.ProductId);
        });
    }
}