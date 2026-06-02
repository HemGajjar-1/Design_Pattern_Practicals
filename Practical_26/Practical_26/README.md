# Practical-26 : CQRS Pattern with ASP.NET Core Web API

## Objective

Implement CRUD operations using ASP.NET Core Web API with CQRS Pattern, Repository Pattern, Unit Of Work, AutoMapper, FluentValidation, and SQL Server.

---

# Project Structure

```text
Practical26
│
├── Practical26.API
│   ├── Controllers
│   │   └── EmployeeController.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── Practical26.Application
│   ├── Command
│   │   ├── CreateEmpCommand.cs
│   │   └── UpdateEmpCommand.cs
│   │
│   ├── Queries
│   │   └── EmployeeQueryDto.cs
│   │
│   ├── Services
│   │   ├── EmployeeCommandService.cs
│   │   └── EmployeeQueryService.cs
│   │
│   ├── Interfaces
│   │   ├── Repository
│   │   │   ├── IGenericCommandRepository.cs
│   │   │   ├── IGenericQueryRepository.cs
│   │   │   └── IUnitOfWork.cs
│   │   │
│   │   └── Service
│   │       ├── IEmployeeCommandService.cs
│   │       └── IEmployeeQueryService.cs
│   │
│   ├── Mapping
│   │   └── MapProfile.cs
│   │
│   └── Validator
│       ├── CreateValidator.cs
│       └── UpdateValidator.cs
│
├── Practical26.DAL
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   │
│   ├── Repository
│   │   ├── GenericCommandRepository.cs
│   │   ├── GenericQueryRepository.cs
│   │   └── UnitOfWork.cs
│   │
│   └── Migrations
│
└── Practical26.Domain
    ├── Base
    │   └── BaseEntity.cs
    │
    └── Entities
        └── Employee.cs
```

---

# Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* CQRS Pattern
* Repository Pattern
* Unit Of Work Pattern
* AutoMapper
* FluentValidation
* Swagger

---

# Employee Table Fields

| Field Name   | Description            |
| ------------ | ---------------------- |
| Id           | Primary Key            |
| Name         | Employee Name          |
| Salary       | Employee Salary        |
| DepartmentId | Department Id          |
| EmailId      | Employee Email         |
| JoiningDate  | Employee Joining Date  |
| Status       | Active/Inactive Status |
| IsDeleted    | Soft Delete Flag       |
| CreatedDate  | Record Creation Date   |
| UpdatedDate  | Record Update Date     |

---

# Features Implemented

* Create Employee
* Update Employee
* Soft Delete Employee
* Get All Employees
* Get Employee By Id
* CQRS Pattern
* Generic Repositories
* Unit Of Work
* Global Query Filter
* AutoMapper Mapping
* FluentValidation
* Swagger API Testing

---

# CQRS Implementation

## Command Side

Handles:

* Create
* Update
* Delete

Files:

* CreateEmpCommand.cs
* UpdateEmpCommand.cs
* EmployeeCommandService.cs
* GenericCommandRepository.cs

## Query Side

Handles:

* Get operations

Files:

* EmployeeQueryDto.cs
* EmployeeQueryService.cs
* GenericQueryRepository.cs

---

# Soft Delete Implementation

Soft delete is implemented using:

* IsDeleted
* Status

Delete operation does not remove record physically.

Instead:

```csharp
entity.IsDeleted = true;
entity.Status = false;
```

Global Query Filter automatically hides deleted records.

---

# AutoMapper

AutoMapper is used to map:

* Command → Entity
* Entity → DTO

Mapping configuration is present in:

* MapProfile.cs

---

# FluentValidation

Validation is implemented for:

* Create Employee
* Update Employee

Validation rules:

* Name required
* Salary > 0
* Valid Email
* Valid DepartmentId

---

# API Endpoints

## Create Employee

```http
POST /api/employee
```

Request Body:

```json
{
  "name": "Hem",
  "salary": 50000,
  "departmentId": 1,
  "emailId": "hem@gmail.com"
}
```

---

## Update Employee

```http
PUT /api/employee
```

Request Body:

```json
{
  "id": 1,
  "name": "Hem Updated",
  "salary": 70000,
  "departmentId": 2,
  "emailId": "hemupdated@gmail.com"
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

# Migration Commands

## Add Migration

```powershell
Add-Migration InitialCreate
```

## Update Database

```powershell
Update-Database
```

---

# Learnings

Implemented CRUD operations using ASP.NET Core Web API with SQL Server and Entity Framework Core, understood Clean Architecture with layered structure, implemented CQRS pattern by separating command and query responsibilities, used Generic Command and Query Repositories for reusable data access logic, implemented Unit Of Work pattern for centralized SaveChanges management, implemented soft delete using IsDeleted and Status fields, used Global Query Filter in Entity Framework Core, implemented AutoMapper for DTO mapping, used FluentValidation for request validation, worked with asynchronous programming using async/await, generated migrations using EF Core, and tested APIs using Swagger.

---

# Result

Successfully implemented Employee CRUD Web API using CQRS Pattern with Repository Pattern, Unit Of Work, AutoMapper, FluentValidation, Soft Delete, SQL Server, and ASP.NET Core Web API.
