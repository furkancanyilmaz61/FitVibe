# FitVibe – Fitness & Nutrition Tracking API

**FitVibe** is a modern, scalable, and multi-layered Web API project developed as a university graduation project. The application allows users to register, log in, manage their workout and nutrition programs, receive coach suggestions, and securely track their fitness journey. Built using clean architecture principles, it features robust authentication, role-based access, and a structured development approach using ASP.NET Core technologies.

---

## ✅ Features

- 🟢 User Registration & Login with JWT Authentication  
- 🔐 Role-Based Authorization (User / Admin)  
- 🏋️ Workout Program Creation, Update, Deletion  
- 👨‍🏫 Coach Management with One-to-Many Relation (Coach → WorkoutProgram)  
- 🔁 Assigning Programs to Users (Many-to-Many Relation)  
- 🔒 Data Protection using ASP.NET Core's IDataProtector  
- ⚠️ Global Exception Handling Middleware  
- 📄 Swagger UI for API Testing and Documentation  
- 🧱 Multi-Layered Clean Architecture  

---

## ⚙️ Tech Stack

- **Backend:** ASP.NET Core Web API  
- **Database:** SQL Server  
- **ORM:** Entity Framework Core (Code First)  
- **Authentication:** JWT (Bearer Token)  
- **Security:** ASP.NET Core Data Protection  
- **Documentation:** Swagger (Swashbuckle)  
- **Mapping:** AutoMapper  
- **IDE:** Visual Studio 2022  

---

## 📁 Project Structure
FitVibe/ ├── FitVibe.Entities# Entity classes and DTOs
├── FitVibe.DataAccess # Repositories and DbContext
├── FitVibe.Business # Services and business logic 
└── FitVibe.WebAPI # Controllers, Middleware, Startup configuration


##🚀 Run the Project

1-Open the solution in Visual Studio
2-Set FitVibe.WebAPI as the startup project
3-Press F5 to run
https://localhost:{port}/swagger

##🔐 Role-Based Access Table
Endpoint                                         	Access Role
/api/Auth/register	                                Public
/api/Auth/login                                   	Public
/api/Coach	                                        Admin
/api/WorkoutProgram                               	Admin
/api/UserWorkoutProgram                           	Admin
/api/User	                                        Admin/User

##📬 Sample API Requests
✅ Register a New User
POST /api/Auth/register
{
  "fullName": "Jane Doe",
  "email": "jane@example.com",
  "password": "SecurePass123"
  "userName": "JanDoe",
}
🔐 Login
{
  "email": "jane@example.com",
  "password": "SecurePass123"
}
👨‍🏫 Create a Coach (Admin only)
POST /api/Coach
Authorization: Bearer {your-token}

🏋️ Create a Workout Program
POST /api/WorkoutProgram
Authorization: Bearer {admin-token}

👨‍💻 Developer
Furkancan Yılmaz
Graduate Management Information Systems
Graduation Project – 2025
Email: furkancaanyilmaz@gmail.com
LinkedIn [(https://www.linkedin.com/in/furkancanyiilmaz/)]







