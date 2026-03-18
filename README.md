# Warranty Claims API

A backend API built with **ASP.NET Core** and **Entity Framework Core** that manages warranty claims using a clean, layered architecture.

---

## 🚀 Features

* RESTful API design
* Layered architecture (Controllers, Services, Data)
* Entity Framework Core for data access
* Input validation and business rules
* Dependency injection
* Unit testing

---

## 🧱 Tech Stack

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server (or InMemory for testing)
* xUnit

---

## 🏗️ Architecture

This project follows a clean, maintainable structure:

* **Controllers** → Handle HTTP requests
* **Services** → Contain business logic
* **Models** → Define domain entities
* **DbContext** → Manage database access

This separation keeps the application scalable and easy to maintain.

---

## 📌 Example Endpoint

```http
POST /api/claims
```

Request:

```json
{
  "title": "Broken Product",
  "description": "The item stopped working after 2 weeks",
  "amount": 120.00
}
```

---

## 🧪 Testing

* Unit tests written using **xUnit**
* Focused on service-layer logic and validation

---

## 💡 What This Project Demonstrates

* Backend API design in ASP.NET Core
* Clean architecture principles
* Separation of concerns
* Data persistence with EF Core
* Writing testable, maintainable code

---

## 🔗 Related Project

Check out the full-stack version of this concept:

👉 Claim Management Platform (React + ASP.NET Core)
