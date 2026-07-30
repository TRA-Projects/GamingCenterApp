# 🎮 Gaming Center Platform

.NET | C# | ASP.NET Core Web API | Entity Framework Core | SQL Server | JWT | Swagger

A backend REST API for a Gaming Center Platform that allows visitors to explore gaming devices and competitions, check available booking slots, make bookings, complete payments, and submit reviews.

---

## 📌 Overview

The Gaming Center Platform is a backend Web API designed to manage gaming center operations and provide visitors with a seamless booking experience.

The system allows visitors to register and log in securely using JWT authentication, browse available gaming devices and competitions, select a booking type, view available slots, create bookings, process payments, and submit reviews.

The project demonstrates backend development concepts including RESTful APIs, Entity Framework Core, SQL Server, JWT Authentication, Repository Pattern, Service Layer, DTOs, and Swagger API documentation.

---

## 🚀 Features

### 👤 Visitor Management
- Visitor Registration
- Visitor Login
- JWT Authentication
- Secure Password Hashing
- Visitor Profile Management

### 🎮 Gaming Device Management
- View Gaming Devices
- Manage Device Information
- Device Categories
- Device Availability

### 🏆 Competition Management
- View Competitions
- Manage Competition Information
- Competition Availability

### 📅 Booking Management
- Select Booking Type
- Book Gaming Devices
- Book Competitions
- View Available Slots
- Create Bookings
- Manage Booking Status

### 💳 Payment Management
- Add Payment
- Update Booking Payment Status
- Track Payment Information

### ⭐ Review Management
- Add Reviews
- Submit Ratings
- Link Reviews to Completed Bookings

---

## 🔐 Authentication

The API uses **JWT (JSON Web Token)** authentication to secure protected endpoints.

### Authentication Flow

```text
Visitor
   │
   ▼
Register
   │
   ▼
Login
   │
   ▼
JWT Token
   │
   ▼
Access Protected Endpoints
