## Car Service Management

A web application for managing a car service center, built with Blazor WebAssembly (Standalone) for the front-end and ASP.NET Core Web API for the back-end, using SQLite as the database. The application allows users to list, add, view details, update and delete customers and their associated works (services).

---

## Features

* **Customer Management**

  * List all customers
  * Add a new customer
  * View and update customer details
  * In customer details window you can check the works associated with the customer

* **Work (Service) Management**

  * List all works
  * Add a new work for a customer
  * View and update work details

---

## Technologies

* **Front-End**: Blazor WebAssembly (Standalone)
* **Back-End**: ASP.NET Core Web API
* **Database**: SQLite
* **ORM**: Entity Framework Core

---

## Prerequisites

* [.NET SDK 9 or later](https://dotnet.microsoft.com/download)
* SQLite (optional, for local database inspection)
* A code editor (e.g., Visual Studio, VS Code)

---

## Getting Started

1. **Clone the Repository**

   ```bash
   git clone https://github.com/SzPeti8/Beadando_AutoService
   cd Beadando_AutoService
   ```

2. **Back-End Setup**

   ```bash
   cd AutoService.Api
   dotnet restore
   dotnet ef database update    # Applies migrations and creates SQLite database
   dotnet run
   ```

   The API will start on `http://localhost:5273`.

3. **Front-End Setup**

   ```bash
   cd AutoService.UI
   dotnet restore
   dotnet run
   ```

   The Blazor WebAssembly app will be available at `https://localhost:7048/`.

---

## Project Structure

```
/AutoService.Api.Tests # API Tests

/AutoService.Api       # ASP.NET Core Web API project
  |- Program.cs
  |- Controllers
  |- Data
  |- Models
  |- Migrations
  |- Services

/AutoService.Shared              # Common DTOs and models
  |- Customer.cs
  |- Work.cs

/AutoService.UI.Tests # UI Tests

/AutoService.UI    # Blazor WebAssembly project
  |- Program.cs
  |- wwwroot
  |- Pages
  |- Services
  |- Layout
  |- Components

README.md
```

---

## API Endpoints

| Method | Route                       | Description                       |
| ------ | --------------------------- | --------------------------------- |
| GET    | `/api/customers`            | Get all customers                 |
| GET    | `/api/customers/{id}`       | Get customer by ID                |
| POST   | `/api/customers/add/`       | Create a new customer             |
| PUT    | `/api/customers/{id}`       | Update existing customer          |
| GET    | `/api/works`                | Get all works                     |
| GET    | `/api/works/{id}`           | Get work by ID                    |
| POST   | `/api/works/add/`           | Create a new work                 |
| PUT    | `/api/works/{id}`           | Update existing work              |
| GET    | `/api/customers/{id}/works` | Get works for a specific customer |

---

## Usage

1. Navigate to the Blazor client app in your browser.
2. Use the navigation menu to access **Customers** or **Works**.
3. In **Customers**, you can view the list, add a new customer, or click a customer to view and edit details.
4. In **Works**, you can view all services, add a new work entry (selecting a customer), or click a work item to view and edit details.
5. To see works for a specific customer, go to the customer details page.

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests for enhancements, bug fixes, or additional features.


