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
        new { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25 },
        new { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100 }
    };
});

// Apply CORS globally
app.UseRouting();

app.Run();