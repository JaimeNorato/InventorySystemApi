using InventorySystemApi.Contexts;
using InventorySystemApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("cnMyInventory"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/products", async ([FromServices] ProductContext bdContext) =>
{
    return Results.Ok(bdContext.Product);
});

app.MapPost("/api/products", async ([FromServices] ProductContext bdContext, [FromBody] Product product) =>
{
    await bdContext.Product.AddAsync(product);
    await bdContext.SaveChangesAsync();

    return Results.Ok(product);
});

app.UseJwtMiddleware();

// app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
