using Hospital_Management_System.Interfaces;
using Hospital_Management_System.Manager;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Menu_Manager
{
    internal class AppointmentMenu   //class to handle user interactions for managing appointments.
    {



        //Dependency Injection ==>Share the same data across the entire application.

        private readonly AppointmentManager _appointmentManager;
        private readonly PatientManager _patientManager;
        private readonly DoctorManager _doctorManager;


        public AppointmentMenu(AppointmentManager appointmentManager, PatientManager patientManager, DoctorManager doctorManager)
        {
            _appointmentManager = appointmentManager;
            _patientManager = patientManager;
            _doctorManager = doctorManager;
        }

        // Helpers for safe input
        private int GetSafeInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Invalid input. Enter a number.");
            }
        }

        private DateTime GetSafeDate(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", null,
                                           System.Globalization.DateTimeStyles.None, out DateTime date))
                    return date;

                Console.WriteLine("Invalid date. Use format: yyyy-MM-dd HH:mm");
            }
        }

        private string Prompt(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }




        //Show Appointment Menu:
        public void ShowAppointmentMenu()
        {
            while (true)
            {
                //Appointment Menu:
                Console.Clear();
                Console.WriteLine("--- Appointment Menu ---");
                Console.WriteLine("1) Add Appointment");
                Console.WriteLine("2) View All Appointments");
                Console.WriteLine("3) Update Appointment");
                Console.WriteLine("4) Delete Appointment");
                Console.WriteLine("5) Back to Main Menu");
                Console.Write("Select an option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine(" Invalid option. Press Enter...");
                    Console.ReadLine();
                    continue;
                }
                switch (option)
                {
                    case 1: // Add Appointment
                        AddAppointment();
                        break;
                    case 2: // View Appointments
                        ViewAppointments();
                        break;
                    case 3: // Update
                        UpdateAppointment();
                        break;
                    case 4: // Delete
                        int idToDelete = GetSafeInt("Enter Appointment ID to delete: ");
                        _appointmentManager.Delete(idToDelete);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        private void AddAppointment()
        {
            var appointment = new Appointment
            {
                AppointmentId = GetSafeInt("Enter Appointment ID: ")
            };

            // Select patient
            var patients = _patientManager.ViewAllPatients();
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients available. Add patients first.");
                return;
            }

            Console.WriteLine("Available Patients:");
            patients.ForEach(p => Console.WriteLine($"- {p.PatientId}: {p.PatientName}"));

            int patientId = GetSafeInt("Enter Patient ID: ");
            var patient = patients.FirstOrDefault(p => p.PatientId == patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            appointment.PatientId = patientId;
            appointment.Patient = patient;

            // Select doctor
            var doctors = _doctorManager.ViewAllDoctor();
            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors available. Add doctors first.");
                return;
            }

            Console.WriteLine("Available Doctors:");
            doctors.ForEach(d => Console.WriteLine($"- {d.DoctorId}: {d.DoctorName}"));

            int doctorId = GetSafeInt("Enter Doctor ID: ");
            var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            appointment.DoctorId = doctorId;
            appointment.Doctor = doctor;

            // Date & Reason
            appointment.AppointmentDate = GetSafeDate("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
            appointment.Reason = Prompt("Enter Reason: ");

            _appointmentManager.AddAppointment(appointment);
        }

        private void ViewAppointments()
        {
            var appointments = _appointmentManager.ViewAllAppointment();
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            Console.WriteLine($"Total Appointments: {appointments.Count}");
            appointments.ForEach(a => Console.WriteLine(a));
        }

        private void UpdateAppointment()
        {
            int id = GetSafeInt("Enter Appointment ID to update: ");
            var existing = _appointmentManager.ViewAllAppointment()
                .FirstOrDefault(a => a.AppointmentId == id);

            if (existing == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            var updated = new Appointment { AppointmentId = id };

            Console.Write("Enter new Patient ID (or press Enter to keep current): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int newPatientId))
            {
                var patient = _patientManager.ViewAllPatients().FirstOrDefault(p => p.PatientId == newPatientId);
                if (patient != null)
                {
                    updated.PatientId = newPatientId;
                    updated.Patient = patient;
                }
            }
            else
            {
                updated.PatientId = existing.PatientId;
                updated.Patient = existing.Patient;
            }

            Console.Write("Enter new Doctor ID (or press Enter to keep current): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int newDoctorId))
            {
                var doctor = _doctorManager.ViewAllDoctor().FirstOrDefault(d => d.DoctorId == newDoctorId);
                if (doctor != null)
                {
                    updated.DoctorId = newDoctorId;
                    updated.Doctor = doctor;
                }
            }
            else
            {
                updated.DoctorId = existing.DoctorId;
                updated.Doctor = existing.Doctor;
            }

            Console.Write("Enter new Date (yyyy-MM-dd HH:mm) (or press Enter to keep current): ");
            input = Console.ReadLine();
            updated.AppointmentDate = string.IsNullOrWhiteSpace(input)
                ? existing.AppointmentDate
                : DateTime.ParseExact(input, "yyyy-MM-dd HH:mm", null);

            Console.Write("Enter new Reason (or press Enter to keep current): ");
            input = Console.ReadLine();
            updated.Reason = string.IsNullOrWhiteSpace(input) ? existing.Reason : input;

            _appointmentManager.UpdateAppointment(updated);
        }
    }
}
