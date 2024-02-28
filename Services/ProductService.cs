using InventorySystemApi.Contexts;
using InventorySystemApi.Models;

namespace InventorySystemApi.Services;

public class ProductService : IProductService
{
    ProductContext context;

    public ProductService(ProductContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Product> Get()
    {
        return context.Products;
    }

    public Product? GetId(Guid productId)
    {
        return context.Products.Find(productId);
    }

    public async Task Save(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
    }
}

public interface IProductService
{
    IEnumerable<Product> Get();
    Product? GetId(Guid productId);
    Task Save(Product product);
}