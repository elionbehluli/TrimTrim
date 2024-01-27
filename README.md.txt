TrimTrim - Barber Shop Appointment System
Project Overview
TrimTrim is a .NET 7 with razor pages-based barber shop appointment system. Users can sign up, log in, and schedule appointments.
The website includes pages for products and services, and administrator have authorization for managing various aspects of the system.

Getting Started

Update Database:
Open appsettings.json and specify your SQL Server's name in the Server field.
Open Package Manager Console and run:
Update-Database

Admin Credentials:

Use the following credentials to log in as an administrator:
Username: admin@example.com
Password: Admin123.
User Patterns (Seeded):
The project includes seeded user data with the following patterns:
Username Pattern: user@example.com
Password Pattern: User123.

Usage
Run the Project:
Click the start button or use command line to run the project in localhost:https://localhost:7055/.

Sign up or log in to access user-specific functionalities.
Set appointments through the scheduling system.
Admin Actions:
Admins have additional authorization to manage users, appointments, products, and services.

## Project Structure
- `DAL/`: The Data Access Layer containing essential database-related components.
- `Migrations/`: Houses migration files that manage database schema changes.
- `Models/`: Holds all data models used throughout the application.
- `Pages/`: Centralizes Razor Pages responsible for diverse web functionalities.

Additional Resources
Git Repository: https://github.com/elionbehluli/TrimTrim.git
Trello Board: https://trello.com/b/MF88rFNA/project-managment