# MinimalBackend and BlazorFrontEnd Solution

This repository contains two projects:

1. **MinimalBackend**: A minimal API backend built with ASP.NET Core that provides product data.
2. **BlazorFrontEnd**: A Blazor WebAssembly frontend that fetches and displays product data from the backend.

## Features

### MinimalBackend

- A lightweight backend that serves a product list with nested category data.
- Includes an in-memory caching strategy to optimize server load.
- Configured with Cross-Origin Resource Sharing (CORS) to enable seamless communication with the Blazor frontend.

### BlazorFrontEnd

- A modern, single-page application (SPA) built with Blazor WebAssembly.
- Fetches product data from the backend using `HttpClient`.
- Displays product information, including nested category details, in a simple and intuitive UI.
- Reduces redundant API calls using conditional checks.

## Getting Started

### Prerequisites

- .NET SDK 6.0 or later
- A web browser (Google Chrome, Firefox, etc.)
- Optionally, a tool like Postman for testing the API.

---

## Running the Backend (MinimalBackend)

1. **Navigate to the MinimalBackend directory:**

   ```bash
   cd MinimalBackend
   ```

2. **Restore dependencies and run the backend:**

   ```bash
   dotnet restore
   dotnet run
   ```

3. **Verify the backend is running:**
   Open your browser and visit `http://localhost:5237/api/productlist` to see the product data in JSON format.

---

## Running the Frontend (BlazorFrontEnd)

1. **Navigate to the BlazorFrontEnd directory:**

   ```bash
   cd BlazorFrontEnd
   ```

2. **Restore dependencies and run the frontend:**

   ```bash
   dotnet restore
   dotnet run
   ```

3. **Verify the frontend is running:**
   Open your browser and visit `http://localhost:5237` to see the product list rendered by the Blazor application.

---

## Code Structure

### MinimalBackend

- **Program.cs**:
  - Sets up CORS, caching, and API routes.
  - Contains the `Product` and `Category` record classes for the data model.
- **Caching**:
  - In-memory caching reduces redundant processing for frequently accessed endpoints.

### BlazorFrontEnd

- **Pages/FetchProducts.razor**:
  - Implements a Razor component to fetch and display product data.
  - Includes conditional checks to minimize redundant API calls.
- **ApiService.cs**:
  - Encapsulates `HttpClient` logic for reusability and clarity.
  - Uses typed deserialization for JSON responses.

---

## Highlights

### Optimizations

1. **Backend Caching**:

   - In-memory caching ensures that data is efficiently served without overloading the server.

2. **Frontend Redundancy Prevention**:

   - Conditional checks in the Razor component ensure API calls are made only when necessary.

3. **Code Refactoring**:
   - `ApiService` centralizes HTTP client logic to avoid repetition and enhance maintainability.

---

## Contributions

This solution was developed collaboratively with Copilot, an AI assistant. Key contributions include:

- Assistance with setting up CORS in the backend.
- Guidance on implementing caching strategies for server optimization.
- Suggestions for reducing redundant API calls in the frontend.
- Code refactoring to improve readability and maintainability.

---

## License

This project is licensed under the MIT License.

## Feedback

Feel free to share any feedback or suggestions for further improvements! 🚀
