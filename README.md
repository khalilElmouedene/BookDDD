# BookDDD - DDD & CQRS with Clean Architecture in ASP.NET Core 5

This project is a proof of concept inspired by the Medium article [“Mise en œuvre de DDD et CQRS dans une Clean Architecture monolithique avec ASP.NET Core 5”](https://medium.com/@kevinenan/mise-en-%C5%93uvre-de-ddd-et-cqrs-dans-une-clean-architecture-monolithique-avec-asp-net-core-5-80559cc04dfc) by Kevin Enan.

It demonstrates how to implement Domain-Driven Design (DDD) and Command Query Responsibility Segregation (CQRS) using a Clean Architecture approach in a monolithic ASP.NET Core 5 application.

---

## 🏗️ Project Structure

The solution is divided into multiple layers:

- **Presentation**: ASP.NET Core Web API layer (entry point)
- **Application**: Use cases, commands, queries, interfaces, and DTOs
- **Domain**: Domain models, value objects, aggregates, domain events
- **Infrastructure**: External service implementations (optional)
- **Persistence**: Data access with repository implementations (e.g., Entity Framework Core)

Each layer respects Clean Architecture principles with inward dependencies and separation of concerns.

---

## 📐 Architectural Concepts

### Clean Architecture
- Layers are independent and communicate via interfaces.
- Business rules (Domain & Application) are isolated from frameworks and technologies.

### Domain-Driven Design (DDD)
- The domain layer models real business logic with entities, aggregates, and value objects.
- Domain services and events encapsulate domain behavior and side effects.

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Write operations (e.g., CreateBook)
- **Queries**: Read operations (e.g., GetBookById)
- Commands and Queries are handled via **MediatR**.

---

## 🧰 Technologies & Tools

- ASP.NET Core 5
- MediatR
- AutoMapper
- FluentValidation
- Entity Framework Core (optional for persistence)
- Clean Architecture
- Domain-Driven Design
- CQRS

---

## ✅ Benefits

- Clear separation between concerns (domain, application, infrastructure)
- Testable and maintainable architecture
- Flexibility to grow into microservices
- Scalable through CQRS pattern

---

## 🚀 Getting Started

1. Clone the repository
2. Open in Visual Studio or VS Code
3. Run the solution
4. Use Swagger/Postman to test endpoints

> **Note:** The infrastructure and persistence layers are placeholders in this POC. You can implement your own database connection and repository logic.

---

## 📚 Resources

- [Medium Article by Kevin Enan](https://medium.com/@kevinenan/mise-en-%C5%93uvre-de-ddd-et-cqrs-dans-une-clean-architecture-monolithique-avec-asp-net-core-5-80559cc04dfc)
- [Clean Architecture by Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture)
- [CQRS with MediatR in ASP.NET Core](https://code-maze.com/cqrs-mediatr-in-aspnet-core/)
- [Microsoft Docs - DDD and CQRS](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/)

---

## 📌 License

This project is for educational purposes and open-source use. Feel free to adapt it to your needs.
