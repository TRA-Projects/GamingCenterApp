# 🎮 Gaming Center Platform
.NET | C# | ASP.NET Core Web API | Entity Framework Core | SQL Server

A Gaming Center Management System built as an ASP.NET Core Web API using Entity Framework Core and SQL Server to manage gaming devices, competitions, bookings, payments, and customer reviews.

📌 Overview
Gaming Center Platform is a backend Web API designed to provide an organized gaming center experience by allowing visitors to explore gaming devices and competitions, check available booking slots, create bookings, complete payments, and submit reviews.

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
➕ Create Records
✏️ Update Records
❌ Delete Records
🔍 Search Records
📄 View All Records
💾 SQL Server Integration
⚡ Entity Framework Core
📚 Swagger API Documentation

📂 Project Structure
GamingCenterApp
│
├── Controllers
├── Models
├── DTOs
├── Data
├── Services
├── Repositories
├── Migrations
└── Program.cs

🎯 Highlights
✅ RESTful Web API
✅ Clean and Organized Project Structure
✅ Entity Framework Core Integration
✅ SQL Server Database
✅ JWT Authentication
✅ Secure Password Hashing
✅ Repository Pattern
✅ Service Layer
✅ DTOs
✅ CRUD Operations
✅ Database Relationships
✅ Input Validation
✅ Swagger API Documentation

🔄 System Workflow
1. Visitor registers a new account.
2. Visitor logs in and receives a JWT token.
3. Visitor views available gaming devices and competitions.
4. Visitor selects a booking type.
5. Visitor views available booking slots.
6. Visitor creates a booking.
7. Visitor completes the payment.
8. Booking status is updated.
9. Visitor submits a review for the completed booking.

📋 Main Modules
Module | Description
------- | -----------
Visitors | Manage visitor registration and authentication
Gaming Devices | Manage gaming devices and their information
Competitions | Manage gaming competitions
Booking Types | Manage gaming device and competition booking types
Available Slots | Manage available booking time slots
Bookings | Create and manage visitor bookings
Payments | Manage booking payment information
Reviews | Manage visitor reviews and ratings

📋 Main Operations
Operation | Description
------- | -----------
Register | Create a new visitor account
Login | Authenticate visitor and generate JWT token
View | Display gaming devices and competitions
Booking | Create a gaming device or competition booking
Payment | Process booking payment
Review | Submit a review and rating
Update | Modify stored information
Delete | Remove stored information
Search | Find specific records

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

⚙️ Getting Started
git clone https://github.com/TRA-Projects/GamingCenterApp.git

cd GamingCenterApp

dotnet restore

dotnet ef database update

dotnet run

📚 API Testing
The API can be tested using Swagger and Postman.

Recommended Testing Flow:

1. Register Visitor
2. Login
3. Copy JWT Token
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
Performing CRUD operations
Implementing Repository Pattern
Using Service Layer architecture
Working with DTOs
Testing APIs using Swagger and Postman
Working with SQL Server databases
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
