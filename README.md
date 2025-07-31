# 🏥 Hospital Management System (Console-Based in C#)

This is a console-based Hospital Management System built with pure C# using Object-Oriented Programming (OOP) principles.

It demonstrates clean architecture with:
- Models for data
- Interfaces & Managers for business logic
- Menu Handlers for console interaction
- JSON data persistence so your data is saved between sessions

## 💡 Features
- Patient Management – Add, View, Update, Delete
- Doctor Management – Add, View, Update, Delete
- Appointment Management – Schedule, View, Update, Delete (auto-linked to patients & doctors)
- Data Persistence – Saves & loads all data using JSON files
- Error Handling – Safe input validation and global crash protection
- Modular & Scalable – Interface-based design, easy to extend

## 🧰 Technologies Used
- Language: C#
- Architecture: Object-Oriented Programming (OOP)
- Data Storage: JSON files using Newtonsoft.Json

## 🚀 How to Run
1. Open the project in Visual Studio or any C# IDE
2. Install Newtonsoft.Json via NuGet
3. Build the solution
4. Run the application
5. Use the console menu to manage Patients, Doctors, and Appointments
6. Exit with Option 4 to save all data to JSON files
