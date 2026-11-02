# Distributed Order Management System

A microservices-based application built with **.NET 10**, demonstrating Clean Architecture, CQRS, and event-driven communication.

## Services

- **Customer Service** – Manages customers.
- **Order Service** – Manages orders.

## Tech Stack

- C# / .NET 10
- ASP.NET Core Minimal APIs
- Entity Framework Core
- PostgreSQL
- RabbitMQ / MassTransit
- Docker Compose

## Architecture

Each service has its own database. Services communicate asynchronously through RabbitMQ.

## Run Locally

Start infrastructure:

```bash
docker compose -f Infrastructure/docker-compose.yml up -d
```

Run the services:

```bash
dotnet run --project Services/CustomerService/Customer.API
dotnet run --project Services/OrderService/Order.API
```

## Status

Under development.
