# 🚀 Customer Management System (Clean Architecture & CQRS)

A simple yet powerful Customer Management System developed with **.NET 8**. The primary goal of this project is to demonstrate the correct implementation of **Clean Architecture** and the **CQRS** pattern in a real-world application.

## 🛠 Technologies & Patterns

This project utilizes modern patterns and tools within the .NET ecosystem:

*   **Framework:** .NET 8 / ASP.NET Core Web API
*   **Architecture:** Clean Architecture (Domain, Application, Infrastructure, Presentation)
*   **Design Patterns:** CQRS, Repository Pattern, Mediator Pattern
*   **Libraries:** 
    *   `MediatR` (Implementing CQRS)
    *   `FluentValidation` (Validation Data in Application Layer)
    *   `Entity Framework Core` (ORM)
*   **Testing:** xUnit, Moq, FluentAssertions
*   **Database:** SQL Server

## ✨ Key Features

*   **CRUD Operations:** Create, Read, Update, and Delete customers.
*   **Rich Domain Model:** Prevents Anemic Domain Model by encapsulating business logic within the Domain layer.
*   **Global Exception Handling:** Centralized error handling returning standard RESTful API responses.
*   **Validation Pipeline:** Utilizing MediatR Pipeline Behaviors for automatic command validation before reaching the handler.
*   **Pagination:** Implemented pagination for retrieving the customer list to improve performance.
*   **Unit Testing:** Comprehensive unit tests to ensure the reliability of the core software.

## 🚀 Getting Started

### Prerequisites
*   [.NET 8 SDK](https://dotnet.microsoft.com/download)
*   SQL Server
*   An IDE like Visual Studio or Rider

### Installation & Execution

1. **Clone the repository:**
```
   git clone https://github.com/Maryamei/CRM.git
```

2. **Configure Connection String:**

Open the appsettings.Development.json file in the Presentation (API) layer and set your database Connection String.

3. **Apply Migrations (Create Database):**

Using Package Manager Console (PMC) in Visual Studio:
```
   dotnet ef database update --project CRM.Infrastructure --startup-project CRM
```
📂 Folder Structure
The project is divided into the following layers based on Clean Architecture concepts:

- Domain: 

The core of the system containing Entities, Value Objects, and Domain Exceptions. It has no dependencies on other layers.
- Application: 

Contains Use Cases (Commands & Queries), Interfaces, and Validation. It depends only on the Domain layer.
- Infrastructure: 

Implementation of external dependencies such as database access (EF Core), file systems, and email services.
- Presentation (API): 

The entry point of the application (Controllers), responsible for receiving requests and forwarding them to the Application layer.

---
**Developed by Maryam Eftekhari**

https://www.linkedin.com/in/maryam-eftekhari-0145121b3/ 