using Hospital_Management_System.Manager;
using Hospital_Management_System.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hospital_Management_System.Services
{
    internal static class DataStorage
    {
        private const string PatientsFile = "patients.json";
        private const string DoctorsFile = "doctors.json";
        private const string AppointmentsFile = "appointments.json";

        public static void SaveAllData(PatientManager patientManager, DoctorManager doctorManager, AppointmentManager appointmentManager)
        {
            File.WriteAllText(PatientsFile, JsonConvert.SerializeObject(patientManager.ListOfPatient, Formatting.Indented));
            File.WriteAllText(DoctorsFile, JsonConvert.SerializeObject(doctorManager.ListOfDoctor, Formatting.Indented));
            File.WriteAllText(AppointmentsFile, JsonConvert.SerializeObject(appointmentManager.ListOfAppointment, Formatting.Indented));
        }

        public static void LoadAllData(PatientManager patientManager, DoctorManager doctorManager, AppointmentManager appointmentManager)
        {
            if (File.Exists(PatientsFile))
            {
                patientManager.ListOfPatient = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(PatientsFile)) ?? new List<Patient>();
            }

            if (File.Exists(DoctorsFile))
            {
                doctorManager.ListOfDoctor = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(DoctorsFile)) ?? new List<Doctor>();
            }

            if (File.Exists(AppointmentsFile))
            {
                appointmentManager.ListOfAppointment = JsonConvert.DeserializeObject<List<Appointment>>(File.ReadAllText(AppointmentsFile)) ?? new List<Appointment>();

                // Re-link Patient and Doctor objects for each appointment
                foreach (var app in appointmentManager.ListOfAppointment)
                {
                    app.Patient = patientManager.ListOfPatient.FirstOrDefault(p => p.PatientId == app.PatientId);
                    app.Doctor = doctorManager.ListOfDoctor.FirstOrDefault(d => d.DoctorId == app.DoctorId);
                }
            }
        }
    }
}
