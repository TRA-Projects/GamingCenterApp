# 🎮 Gaming Center Platform

.NET | C# | ASP.NET Core Web API | Entity Framework Core | SQL Server | JWT | Swagger

A Gaming Center Management System built using ASP.NET Core Web API, Entity Framework Core, and SQL Server to manage gaming devices, competitions, bookings, payments, and customer reviews.

📌 Overview

The Gaming Center Platform is a backend Web API designed to provide visitors with a simple and organized way to explore gaming devices and competitions, check available booking slots, make bookings, complete payments, and submit reviews.

The project demonstrates RESTful API development, Entity Framework Core relationships, CRUD operations, JWT authentication, password hashing, Repository Pattern, Service Layer, DTOs, and Swagger API documentation.

🚀 Features

👤 Visitor Management
🔐 User Registration & Login
🎮 Gaming Device Management
🏆 Competition Management
📅 Booking Management
🕐 Available Slot Management
💳 Payment Management
⭐ Review Management
🔑 JWT Authentication
🔒 Password Hashing
📊 CRUD Operations
📚 Swagger API Documentation
💾 SQL Server Integration
⚡ Entity Framework Core

📂 Project Structure

GamingCenterApp
│
├── Controllers
├── Services
├── Repositories
├── DTOs
├── Models
├── Data
├── Migrations
└── Program.cs

🎯 Main Modules

Module | Description
------- | -----------
Visitors | Manage visitor registration and authentication
Gaming Devices | View and manage available gaming devices
Competitions | View and manage gaming competitions
Booking Types | Select gaming device or competition booking
Available Slots | View available booking time slots
Bookings | Create and manage bookings
Payments | Process booking payments
Reviews | Submit reviews and ratings

🔄 System Workflow

1. Visitor registers an account.
2. Visitor logs in and receives a JWT token.
3. Visitor views available gaming devices and competitions.
4. Visitor selects a booking type.
5. Visitor selects an available time slot.
6. Visitor creates a booking.
7. Visitor completes the payment.
8. Booking status is updated.
9. Visitor can submit a review for the completed booking.

🔐 Authentication Flow

Register
   ↓
Login
   ↓
JWT Token
   ↓
Authorize Request
   ↓
Access Protected Endpoints

🛠️ Tech Stack

C#
.NET
ASP.NET Core Web API
Entity Framework Core
SQL Server
LINQ
JWT Authentication
BCrypt Password Hashing
Swagger / OpenAPI
Git & GitHub

🎯 Highlights

✅ RESTful Web API
✅ Layered Architecture
✅ Repository Pattern
✅ Service Layer
✅ DTOs
✅ JWT Authentication
✅ Secure Password Hashing
✅ Entity Framework Core
✅ SQL Server Database
✅ CRUD Operations
✅ Database Relationships
✅ Swagger API Documentation
✅ GitHub Collaboration

⚙️ Getting Started

git clone https://github.com/TRA-Projects/GamingCenterApp.git

cd GamingCenterApp

dotnet restore

dotnet ef database update

dotnet run

📚 API Testing

The API can be tested using Swagger or Postman.

Recommended Testing Flow:

1. Register Visitor
2. Login
3. Get JWT Token
4. Authorize using JWT Token
5. Get All Gaming Devices
6. Get All Competitions
7. Select Booking Type
8. Get Available Slots
9. Create Booking
10. Add Payment
11. Add Review

📚 What I Learned

Building RESTful Web APIs using ASP.NET Core
Implementing JWT Authentication
Securing passwords using BCrypt hashing
Designing relational databases
Implementing Entity Framework Core relationships
Using Repository and Service Layer patterns
Working with DTOs
Performing CRUD operations
Testing APIs using Swagger and Postman
Working with SQL Server
Collaborating using Git and GitHub

🚀 Future Improvements

Admin Dashboard
Online Payment Gateway
Email Notifications
Booking Cancellation
Advanced Role-Based Authorization
Unit Testing
Integration Testing
Docker Support
CI/CD Pipeline

👩‍💻 Project

Gaming Center Platform

Developed as a collaborative backend project using ASP.NET Core Web API, Entity Framework Core, and SQL Server.
