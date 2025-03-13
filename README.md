# Course Enrollment System

## Description
The **Course Enrollment System** is a web application developed using **ASP.NET MVC** and **Entity Framework (Code-First)**. It enables to manage students, courses, and enrollments while following an **n-tier architecture** for better maintainability and scalability.

## Features
### 1. Student Management
- Add, edit, delete, and list students.

### 2. Course Management
- Add, edit, delete, and list courses.
- View the students enrolled in a course.

### 3. Enrollment Management
- Enroll students in courses.
- Prevent enrollment if the course is full.
- Prevent duplicate enrollments (student already enrolled).
- Display available slots dynamically using jQuery.

## Built With
- **ASP.NET Core MVC** - A rich framework for building web apps and APIs using the Model-View-Controller design pattern.
- **Entity Framework Core** - Utilizes an **In-Memory Database** for easy data handling and testing.

## Architecture
The project follows an **n-tier architecture**:
- **Presentation Layer**: `CodeZone.Web`
- **Business Layer**: `CodeZone.Business`
- **Data Layer**: `CodeZone.DataAccess`

## UI/UX Enhancements
- **Pagination**: Implemented for the Course List and Students List to enhance navigation.
- **Dynamic Slot Display**: Utilizes **jQuery** to dynamically show available slots for course enrollment.
- **Partial Views**: Used to optimize page rendering and enhance modularity.

## Installation & Setup
1. **Clone the Repository**
   ```sh
   git clone https://github.com/MahmoudAbdElNaby136/Course-Enrollment-System
   cd Course-Enrollment-System
   ```
2. **Open the Project**
   - Open the solution in **Visual Studio**.
   - Ensure **.NET Core SDK** is installed.

3. **Run the Application**
   - Select `IIS Express` or run via `dotnet run`.
   - The application will start .

## Contributing
developing by: https://github.com/MahmoudAbdElNaby136


