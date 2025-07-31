🏥 Hospital Management System (Console-Based in C#)

This is a console-based Hospital Management System built with pure C# using Object-Oriented Programming (OOP) principles.

It demonstrates clean architecture with:
-Models for data
-Interfaces & Managers for business logic
-Menu Handlers for console interaction
-JSON data persistence so your data is saved between sessions




💡 Features

Patient Management – Add, View, Update, Delete

Doctor Management – Add, View, Update, Delete

Appointment Management – Schedule, View, Update, Delete (auto-linked to patients & doctors)

Data Persistence – Saves & loads all data using JSON files

Error Handling – Safe input validation and global crash protection

Modular & Scalable – Interface-based design, easy to extend



🧰 Technologies Used

Language: C#
Architecture: Object-Oriented Programming (OOP)
Data Storage: JSON files using Newtonsoft.Json





🗂️ Project Structure

HospitalManagementSystem/
│
├── Models/             # Data classes (Patient, Doctor, Appointment)
├── Interfaces/         # CRUD interfaces (IPatient, IDoctor, IAppointment)
├── Manager/            # Business logic (PatientManager, DoctorManager, AppointmentManager)
├── Menu_Manager/       # Console menu handlers for each module
├── Services/           # DataStorage for JSON save/load
├── Program.cs          # Entry point with global try-catch and main menu
└── README.md           # Project overview




🚀 How to Run

Open the project in Visual Studio or any C# IDE

Install Newtonsoft.Json via NuGet:

Build the solution 

Run the application 

Use the console menu to manage Patients, Doctors, and Appointments

Exit with Option 4 to save all data to JSON files
