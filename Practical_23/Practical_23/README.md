# Practical-23 - Factory Design Pattern / Abstract Factory Design Pattern with CRUD Web API

## Objective

Develop a layered ASP.NET Core Web API application using:

* CRUD Operations
* Repository Pattern
* Generic Repository
* Unit Of Work
* Service Layer
* Factory Design Pattern
* Abstract Factory Design Pattern
* Entity Framework Core
* SQL Server

---

# Project Structure

```text
Practical23
│
├── Practical23.API
├── Practical23.BAL
├── Practical23.DAL
└── Practical23.Domain
```

---

# Architecture Flow

```text
Controller
   ↓
Service Layer
   ↓
Unit Of Work
   ↓
Repository Layer
   ↓
DbContext
   ↓
SQL Server
```

---

# Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger
* AutoMapper
* Repository Pattern
* Generic Repository
* Unit Of Work
* Factory Pattern
* Abstract Factory Pattern

---

# Database Table

## Employees

| Column Name  | Description            |
| ------------ | ---------------------- |
| Id           | Primary Key            |
| Name         | Employee Name          |
| Salary       | Employee Salary        |
| DepartmentId | Employee Department    |
| EmailId      | Employee Email         |
| JoiningDate  | Employee Joining Date  |
| Status       | Active/Inactive Status |
| IsDeleted    | Soft Delete Flag       |

---

# Department Types

```text
1 - IT
2 - Admin
3 - HR
4 - Sales
5 - OnSite
```

---

# CRUD APIs

## Create Employee

### Endpoint

```text
POST /api/employee
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

---

## Update Employee

### Endpoint

```text
PUT /api/employee
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

---

## Delete Employee (Soft Delete)

### Endpoint

```text
DELETE /api/employee/1
```

### Functionality

* Sets:

  * IsDeleted = true
  * Status = false

---

## Get Employees

### Get All Employees

```text
GET /api/employee
```

### Get Employee By Id

```text
GET /api/employee?id=1
```

---

# Global Query Filter

Soft deleted employees are hidden using EF Core Global Query Filter.

```csharp
modelBuilder.Entity<Employee>()
    .HasQueryFilter(x => !x.IsDeleted);
```

---

# Factory Design Pattern

## Objective

Calculate overtime pay dynamically based on employee department.

---

# Overtime Calculations

| Department | Calculation |
| ---------- | ----------- |
| IT         | hour * 200  |
| HR         | hour * 150  |
| Admin      | hour * 120  |
| Sales      | hour * 100  |
| OnSite     | hour * 250  |

---

# Factory Pattern Components

## Interface

```text
IOvertimeCalculator
```

## Concrete Classes

```text
ITOvertimeCalculator
HROvertimeCalculator
AdminOvertimeCalculator
SalesOvertimeCalculator
OnSiteOvertimeCalculator
```

## Factory

```text
DepartmentFactory
```

---

# Factory Pattern API

## Endpoint

```text
GET /api/overtime/factory?employeeId=1&hours=5
```

## Sample Response

```json
{
  "success": true,
  "message": "Overtime calculated successfully.",
  "data": {
    "employeeId": 1,
    "department": "IT",
    "hours": 5,
    "overtimePay": 1000
  }
}
```

---

# Abstract Factory Design Pattern

## Indoor Factory

Handles:

* IT
* HR
* Admin

## Outdoor Factory

Handles:

* Sales
* OnSite

---

# Abstract Factory Components

## Abstract Factory Interface

```text
IDepartmentFactory
```

## Concrete Factories

```text
IndoorFactory
OutdoorFactory
```

## Factory Producer

```text
FactoryProducer
```

---

# Abstract Factory API

## Endpoint

```text
GET /api/overtime/abstract-factory?employeeId=1&hours=5
```

---

# NuGet Packages Used

```text
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
AutoMapper.Extensions.Microsoft.DependencyInjection
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

# Key Concepts Implemented

* CRUD Operations
* Layered Architecture
* DTO Pattern
* Repository Pattern
* Generic Repository
* Unit Of Work
* Service Layer
* Dependency Injection
* AutoMapper
* Soft Delete
* Global Query Filter
* Factory Design Pattern
* Abstract Factory Design Pattern
* Entity Framework Core
* SQL Server Integration

---

# Conclusion

This practical demonstrates implementation of enterprise-level ASP.NET Core Web API architecture using Repository Pattern, Service Layer, Factory Pattern, and Abstract Factory Pattern along with complete Employee CRUD operations and overtime calculation logic based on employee departments.
