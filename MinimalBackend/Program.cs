// MinimalBackend/Program.cs
// This file is part of the MinimalBackend project.

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(); // Add CORS services


var app = builder.Build();

// Add this line to enable CORS
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/api/productlist", () =>
{
    return new[]
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new Category { Id = 101, Name = "Electronics" }
        },
        new Product
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new Category { Id = 102, Name = "Accessories" }
        }
    };
});

//app.UseRouting();
app.Run();

record Product
{
    public int Id { get; init; }
    public string Name { get; init; }
    public double Price { get; init; }
    public int Stock { get; init; }
    public Category Category { get; init; }
}

record Category
{
    public int Id { get; init; }
    public string Name { get; init; }
}

