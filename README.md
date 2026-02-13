# BulkSMS Management System

## Overview
BulkSMS is a full-stack ASP.NET MVC application designed to manage bulk messaging operations. The system allows administrators to create, schedule, and manage SMS campaigns while maintaining proper separation of concerns using a layered architecture.

This project demonstrates enterprise-style structuring using ASP.NET MVC, Web API, Core business logic, and SQL Server with stored procedures.

---

## Architecture

The solution follows a layered architecture:

- **AA.BulkSMS.UI** → ASP.NET MVC Frontend
- **AA.BulkSMS.Web.API** → RESTful API Layer
- **AA.BulkSMS.Core** → Business Logic & Services
- **SQL Server** → Database (Stored Procedures & Raw SQL)

### Architecture Flow

UI (MVC)
↓
Web API
↓
Core (Business Logic)
↓
SQL Server (Stored Procedures)

---

## Features

- SMS Campaign Management
- Scheduling Functionality
- Profile Management
- Stored Procedure Integration
- Raw SQL Execution
- Layered Clean Architecture
- Separation of Concerns
- Full Frontend Interface

---

## Tech Stack

- ASP.NET MVC
- ASP.NET Web API
- C#
- SQL Server
- Stored Procedures
- Raw SQL
- Visual Studio
- Git

---

## Database Design

The system uses SQL Server with:
- Stored Procedures for secure data operations
- Structured relational database design
- Role-based data handling

---

## Project Structure

BulkSMS/
│
├── AA.BulkSMS.UI
├── AA.BulkSMS.Web.API
├── AA.BulkSMS.Core
└── README.md

---

## How to Run

1. Clone the repository
2. Open the solution file (.sln) in Visual Studio
3. Configure your SQL Server connection string in `appsettings.json`
4. Run the Web API project
5. Set the UI project as startup project
6. Launch the application

---

## Author

Tshepo Ngozwana  
Backend Developer (ASP.NET)
