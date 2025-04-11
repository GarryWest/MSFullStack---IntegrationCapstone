// MinimalBackend/Program.cs
// This file is part of the MinimalBackend project.
// It sets up a minimal API backend for product data and demonstrates industry best practices.

using Microsoft.Extensions.Caching.Memory; // Required for IMemoryCache
// Contributions from Copilot include:
// - Assistance with setting up the CORS policy for seamless client-server communication.
// - Structuring the data model using records for clarity and immutability.
// - Enhancing readability with comments and refining the code structure.

var builder = WebApplication.CreateBuilder(args);

// Add CORS services to allow cross-origin requests.
// CORS is essential when the frontend (running in the browser) communicates with a backend on a different domain or port.
builder.Services.AddCors();
builder.Services.AddMemoryCache(); // Add caching services

var app = builder.Build();

// Enable CORS middleware to allow all origins, methods, and headers.
// This simplifies development but should be scoped down in production for security.
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Define an API endpoint to fetch a list of products.
// The endpoint returns a sample dataset containing product information,
// including nested category data for hierarchical organization.
app.MapGet("/api/productlist", (IMemoryCache cache) =>
{
    const string cacheKey = "ProductList";
    if (!cache.TryGetValue(cacheKey, out object productList))
    {
        // If cache misses, load data
        productList = new[]
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

        // Save data in cache for 5 minutes
        cache.Set(cacheKey, productList, TimeSpan.FromMinutes(5));
    }

    return productList;
});

// Run the application.
// This starts the server and listens for incoming requests.
app.Run();

// Data model for Product.
// Records are used to represent immutable objects, aligning with modern development practices.
record Product
{
    public int Id { get; init; }
    public string Name { get; init; }
    public double Price { get; init; }
    public int Stock { get; init; }
    public Category Category { get; init; } // Nested object representing the product's category.
}

// Data model for Category.
// Represents additional context for products, enabling better categorization in the API response.
record Category
{
    public int Id { get; init; }
    public string Name { get; init; }
}