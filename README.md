# CQRS + MediatR ASP.NET Core API

Simple API built using ASP.NET Core and MediatR to demonstrate how to easily implement the CQRS pattern in .NET applications.

The example API is very simple, exposing HTTP endpoints through `/api/users` that internally use MediatR to handle requests and responses.

## Frameworks and Libraries
- [ASP.NET Core 2.2](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2);
- [MediatR](https://github.com/jbogard/MediatR) (mediator pattern implementation for .NET);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (for data access);
- [Entity Framework In-Memory Provider](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory) (for testing purposes);
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) (API documentation).

## How to Test

Run the following commands, in sequence, inside the application directory:

```
dotnet restore
dotnet run
```

Navigate to `http://localhost:5000/swagger/index.html` to check the API documentation and test all endpoints.

## Limitations

The API does not show how to implement distinct databases to read and write data, nor shows advanced synchronization features. The application just shows examples of using MeadiatR and, consequently, the mediator pattern to handle request and responses in a CQRS approach.