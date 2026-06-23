# ProjectManagementSolution

# ASP.NET Core Web API

A production-ready ASP.NET Core Web API developed using modern software engineering practices and design patterns. 
This project demonstrates scalable API development with clean architecture, dependency injection, centralized exception handling, and secure authentication mechanisms.

## Features

* ASP.NET Core Web API
* RESTful API Design
* Entity Framework Core
* Dependency Injection (DI)
* Repository Pattern
* Global Exception Handling Middleware
* Structured Logging
* JWT Authentication & Authorization
* Clean Architecture Principles
* SQL Server Integration
* Swagger/OpenAPI Documentation
* Asynchronous Programming (Async/Await)
* Input Validation
* Scalable and Maintainable Code Structure

## Technology Stack

* ASP.NET Core
* C#
* Entity Framework Core
* SQL Server
* Swagger/OpenAPI
* JWT Authentication
* LINQ

## Project Goals

This project was created to demonstrate enterprise-level API development practices 
including security, maintainability, performance optimization, exception handling, and clean code principles.


## API Capabilities

* CRUD Operations
* Authentication & Authorization
* Data Validation
* Error Handling
* Database Operations
* API Documentation


## Future Enhancements

* Redis Caching
* Unit Testing
* Integration Testing
* Docker Support
* CI/CD Pipeline
* Azure Deployment
* API Versioning
* Rate Limiting


## Configuring EFCORE:


01. Install required Packages (3)
	Microsoft.EntityFrameworkCore
	Microsoft.EntityFrameworkCore.SqlServer
	Microsoft.EntityFrameworkCore.Tools
	
02.	Install one more Package for Api Documentation
	Scalar.AspNetCore
	
03.	Added configuration in appsetting.json file
	"ConnectionStrings": {
			"DefaultConnection": "Server=.;Database=ProjectManagementAppDB;Trusted_Connection=True;TrustServerCertificate=True;"
	}
	
04.	Added Models Folder and added their classes

05.	Add Data Folder and added their classes
06.	Added DbContext File/class
07.	ApplicationDbContext class and registered in Program.cs class
	
08.	Roles

09.	UserRoles

10.	Fluent Api configuration

11.	Migration Task/Work/Command
	add-migration "PMAConfigurationMigration"
	update-database
	
12.	Clean Up the code

13.	How to check our code through OpenAPI
	https://localhost:7022/openapi/v1.json
	
14.	How to check our code through Scalar
	https://localhost:7022/scalar/