# Practical-25 : Mediator Pattern with CQRS in ASP.NET Core Web API

## Objective

Implement CRUD operations using:

* ASP.NET Core Web API
* MediatR (Mediator Pattern)
* CQRS (Command Query Responsibility Segregation)
* Entity Framework Core
* Repository Pattern
* Generic Repository
* Unit Of Work
* FluentValidation
* SQL Server
* Soft Delete

---

# Project Structure

```text
Practical25.API
Practical25.Application
Practical25.Domain
Practical25.DAL
```

---

# Architecture Flow

```text
API → Application → DAL → Database
```

* API Layer

  * Controllers
  * Swagger Configuration

* Application Layer

  * CQRS Commands & Queries
  * MediatR Handlers
  * DTOs
  * Validators
  * Interfaces

* Domain Layer

  * Entities
  * Enums

* DAL Layer

  * DbContext
  * Repository Pattern
  * Generic Repository
  * Unit Of Work

---

# Features Implemented

## CRUD Operations

### Create Employee

Create employee using:

* Name
* Salary
* DepartmentId
* EmailId

### Update Employee

Update employee using:

* Id
* Name
* Salary
* DepartmentId
* EmailId

### Delete Employee (Soft Delete)

Deactivate employee using:

* Id

Soft delete implementation:

```csharp
employee.Status = false;
employee.IsDeleted = true;
```

### Get Employee

* Get all employees
* Get employee by Id

---

# Database Table

## Employees

| Column Name  | Description            |
| ------------ | ---------------------- |
| Id           | Primary Key (Identity) |
| Name         | Employee Name          |
| Salary       | Employee Salary        |
| DepartmentId | Department Enum        |
| EmailId      | Employee Email         |
| JoiningDate  | Employee Joining Date  |
| Status       | Active/Inactive        |
| IsDeleted    | Soft Delete Flag       |

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

# Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* MediatR
* CQRS
* FluentValidation
* Swagger

---

# NuGet Packages Used

## Practical25.API

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Swashbuckle.AspNetCore
```

## Practical25.Application

```powershell
Install-Package MediatR.Extensions.Microsoft.DependencyInjection
Install-Package FluentValidation
Install-Package FluentValidation.DependencyInjectionExtensions
```

## Practical25.DAL

```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

# Entity Framework Migration Commands

## Add Migration

```powershell
Add-Migration InitialCreate
```

## Update Database

```powershell
Update-Database
```

---

# API Endpoints

## Create Employee

```http
POST /api/employee
```

Request:

```json
{
  "name": "Hem",
  "salary": 50000,
  "departmentId": 1,
  "emailId": "hem@test.com"
}
```

---

## Update Employee

```http
PUT /api/employee
```

Request:

```json
{
  "id": 1,
  "name": "Hem Updated",
  "salary": 70000,
  "departmentId": 2,
  "emailId": "hemupdated@test.com"
}
```

---

## Delete Employee

```http
DELETE /api/employee/1
```

---

## Get All Employees

```http
GET /api/employee
```

---

## Get Employee By Id

```http
GET /api/employee?id=1
```

---

# CQRS Structure

```text
Features
 └── Employees
      ├── Commands
      │     ├── CreateEmployee
      │     ├── UpdateEmployee
      │     └── DeleteEmployee
      │
      └── Queries
            └── GetEmployee
```

---

# Mediator Pattern

MediatR is used to decouple Controllers from Business Logic.

Flow:

```text
Controller → MediatR → Handler → Repository → Database
```

Benefits:

* Loose Coupling
* Better Separation of Concerns
* Cleaner Code
* Scalable Architecture

---

# FluentValidation

Validation is implemented for:

* Name
* Salary
* EmailId

Example:

```csharp
RuleFor(x => x.EmailId)
    .NotEmpty()
    .EmailAddress();
```

---

# Soft Delete Implementation

Global query filter is used:

```csharp
modelBuilder.Entity<Employee>()
    .HasQueryFilter(x => !x.IsDeleted);
```

Deleted employees are automatically hidden from queries.

---

# Repository Pattern

Implemented:

* Generic Repository
* Employee Repository
* Unit Of Work

Benefits:

* Reusable Data Access Logic
* Cleaner Architecture
* Better Maintainability

---

# Outcome

Successfully implemented:

* CRUD Operations
* Mediator Pattern
* CQRS Architecture
* FluentValidation
* Repository Pattern
* Unit Of Work
* Soft Delete
* ASP.NET Core Web API
* SQL Server Integration
