# Practical-24 - Repository Pattern with CRUD Web API in .NET Core

## Objective

Create a layered ASP.NET Core Web API project using Clean Architecture and Repository Pattern.
Implement CRUD operations for Employee management with SQL Server and Entity Framework Core.

---

# Project Architecture

Solution Structure:

```text
Practical24
│
├── Practical24.API
├── Practical24.Application
├── Practical24.Domain
└── Practical24.Infrastructure
```

---

# Project Responsibilities

## Practical24.API

Contains:

* Controllers
* Swagger configuration
* Dependency Injection
* Program.cs

## Practical24.Application

Contains:

* DTOs
* Interfaces
* Services
* Business Logic

## Practical24.Domain

Contains:

* Entities
* Enums

## Practical24.Infrastructure

Contains:

* DbContext
* Repository Pattern
* Generic Repository
* Unit Of Work
* Database Connection

---

# Features Implemented

* Clean Architecture
* Repository Pattern
* Generic Repository
* Unit Of Work
* Service Layer
* DTO Pattern
* Entity Framework Core
* SQL Server Connection
* CRUD Operations
* Soft Delete
* Deactivate Employee
* Dependency Injection
* Swagger Integration
* Async/Await Programming

---

# Employee Table Structure

| Column Name  | Data Type      |
| ------------ | -------------- |
| Id           | int (Identity) |
| Name         | nvarchar       |
| Salary       | decimal        |
| DepartmentId | int            |
| EmailId      | nvarchar       |
| JoiningDate  | datetime       |
| Status       | bit            |
| IsDeleted    | bit            |

---

# Department Enum

```csharp
public enum Department
{
    IT = 1,
    Admin,
    HR,
    Sales,
    OnSite
}
```

---

# NuGet Packages Used

## Practical24.Infrastructure

```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

## Practical24.API

```powershell
Install-Package Swashbuckle.AspNetCore
```

---

# Database Configuration

## Connection String

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Practical24Db;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

# Migration Commands

## Add Migration

```powershell
Add-Migration InitialCreate -StartupProject Practical24.API
```

## Update Database

```powershell
Update-Database -StartupProject Practical24.API
```

---

# CRUD APIs

## 1. Get All Employees

### Request

```http
GET /api/Employee
```

### Description

Returns all active and non-deleted employees.

---

## 2. Get Employee By Id

### Request

```http
GET /api/Employee?id=1
```

### Description

Returns employee details by Id.

---

## 3. Create Employee

### Request

```http
POST /api/Employee
```

### Request Body

```json
{
  "name": "Hem",
  "salary": 50000,
  "departmentId": 1,
  "emailId": "hem@gmail.com"
}
```

### Description

Creates a new employee.

---

## 4. Update Employee

### Request

```http
PUT /api/Employee
```

### Request Body

```json
{
  "id": 1,
  "name": "Hem Updated",
  "salary": 70000,
  "departmentId": 2,
  "emailId": "hemupdated@gmail.com"
}
```

### Description

Updates employee details by Id.

---

## 5. Deactivate Employee

### Request

```http
PATCH /api/Employee/Deactivate/1
```

### Description

Changes employee Status to false.

---

## 6. Soft Delete Employee

### Request

```http
DELETE /api/Employee/1
```

### Description

Performs soft delete by setting IsDeleted = true.

---

# Repository Pattern

Repository Pattern is used to separate data access logic from business logic.

Benefits:

* Better code maintainability
* Loose coupling
* Easier testing
* Cleaner architecture
* Reusable data access code

---

# Generic Repository

Generic Repository is used to avoid duplicate CRUD code for multiple entities.

Implemented Methods:

* GetAllAsync()
* GetByIdAsync()
* AddAsync()
* Update()
* Delete()
* FindAsync()

---

# Unit Of Work

Unit Of Work manages all repositories and saves changes using a single DbContext instance.

Benefits:

* Centralized transaction handling
* Better repository management
* Cleaner code structure

---

# Soft Delete

Instead of permanently deleting records from database:

```csharp
employee.IsDeleted = true;
```

Benefits:

* Data recovery possible
* Audit/history maintained
* Safer deletion process

---

# Service Layer

Service Layer contains:

* Business logic
* DTO mapping
* Validation logic
* Repository communication

---

# Swagger Testing

Swagger UI is used for testing APIs.

Swagger URL:

```text
https://localhost:{port}/swagger
```

---

# Concepts Learned

* ASP.NET Core Web API
* Layered Architecture
* Clean Architecture
* Entity Framework Core
* SQL Server Integration
* CRUD Operations
* Repository Pattern
* Generic Repository
* Unit Of Work
* DTO Pattern
* Dependency Injection
* Swagger
* Soft Delete
* Async/Await
* LINQ Queries

---

# Conclusion

In this practical, a complete Employee Management Web API was developed using ASP.NET Core with Clean Architecture and Repository Pattern. CRUD operations, soft delete functionality, service layer, dependency injection, Entity Framework Core, and SQL Server integration were successfully implemented following best practices.
