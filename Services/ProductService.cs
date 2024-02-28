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

    public async Task Save(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
    }
}

public interface IProductService
{
    IEnumerable<Product> Get();
    Task Save(Product product);
}