---

# Job Search System API

A **.NET 7 Web API** project for managing job postings, applicants, companies, and associated metadata in a scalable, clean architecture. This API is built using modern design patterns like **Repository-Service pattern**, **DTO mapping**, and **JWT authentication** to facilitate a clean, maintainable backend for job search platforms.

---

## 🚀 Tech Stack

| Technology                        | Purpose                                       |
| --------------------------------- | --------------------------------------------- |
| **.NET 7 / 8**                    | Backend framework (Web API)                   |
| **Entity Framework Core**         | ORM for database interactions                 |
| **MSSQL Server**                  | Relational database                           |
| **AutoMapper**                    | Object-Object mapping between Entities & DTOs |
| **JWT Authentication**            | Securing API endpoints                        |
| **Swagger (Swashbuckle)**         | API documentation and testing                 |
| **FluentValidation** *(optional)* | Model validation                              |


---

## 📁 Project Structure

```
/JobSearchSystem.API         --> Presentation Layer (Controllers, Middlewares, Program.cs)
/JobSearchSystem.Business    --> Business Logic Layer (Services, DTOs, Mappings, Exceptions)
/JobSearchSystem.DAL         --> Data Access Layer (EF Context, Repositories, Configurations)
/JobSearchSystem.Tests       --> [Planned] Unit & Integration Tests (xUnit, Moq)
```

---

## ⚙️ Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/seferovrusif/API_WebSite_JobSearchSystem.git
cd API_WebSite_JobSearchSystem
```

### 2. Configure Database Connection

In `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=JobSearchDB;Trusted_Connection=True;"
}
```

### 3. Run Migrations

```bash
cd JobSearchSystem.API
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

Swagger UI available at:
`https://localhost:5001/swagger/index.html`

---

## 🔐 Authentication

* **Login**: `POST /api/Auth/login`
* **Register**: `POST /api/Auth/register`
* Bearer Token (JWT) must be included in the Authorization header to access protected endpoints.

Example:

```
Authorization: Bearer {token}
```

---

## 📌 API Modules Overview

| Module             | Description                                      |
| ------------------ | ------------------------------------------------ |
| **Auth**           | Authentication & Authorization (Login/Register)  |
| **Vacancies**      | Manage job vacancies                             |
| **Companies**      | Company CRUD operations                          |
| **Applyers**       | Job application submissions                      |
| **Social Media**   | Social media links and types                     |
| **Salary**         | Salary range configurations                      |
| **Categorization** | Job categories, cities, genders, education, etc. |

---

## 🧪 Planned Features

* ✅ Clean Layered Architecture
* ✅ Exception Handling Middleware
* ✅ JWT Role-based Authorization
* ✅ DTO Mapping via AutoMapper
* ✅ Modular Repositories & Services
* 🟡 **\[Planned]** Email Notification Service
* 🟡 **\[Planned]** Frontend 

--

## 📝 API Documentation

Swagger UI:
`https://localhost:5001/swagger/index.html`

OpenAPI compliant for easy testing and external integration (Postman collection exportable).

---

## 🤝 Contributing

---

## 👨‍💻 Author

* **Rusif Safarov** – [GitHub Profile](https://github.com/seferovrusif)

--