namespace InventorySystemApi.Contexts

using Microsoft.EntityFrameworkCore;
using InventorySystemApi.Models;


public class ProductContext : DbContext
{
    public DbSet<InventoryMovement> InventoryMovements { get; set; }
    public DbSet<Product> Product { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options){}

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Product>().ToTable("Product");
    //     modelBuilder.Entity<InventoryMovement>().ToTable("InventoryMovement");
    // }
}