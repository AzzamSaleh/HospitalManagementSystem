using Hospital_Management_System.Interfaces;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Manager
{
    internal class AppointmentManager : IAppointment // (implements IAppointment ==>(CRUD) Operation)
    {

        public List<Appointment> ListOfAppointment { get; set; }
        // (list that contains Appointment objects).

        public AppointmentManager()
        {

            //To give a initial Value for ListOfAppointment

            ListOfAppointment = new List<Appointment>();
        }



        //implements for (CRUD) Operation:
        public void AddAppointment(Appointment appointment)
        {
            if (ListOfAppointment.Any(x => x.AppointmentId == appointment.AppointmentId))
            {
                Console.WriteLine("Appointment ID already exists.");
                return;
            }

            ListOfAppointment.Add(appointment);
            Console.WriteLine("Appointment added successfully.");
        }


        public void Delete(int id)
        {
            var appointment = ListOfAppointment.FirstOrDefault(x => x.AppointmentId == id);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found!");
                return;
            }

            ListOfAppointment.Remove(appointment);
            Console.WriteLine($" Appointment {id} deleted.");
        }



        public void UpdateAppointment(Appointment updatedAppointment)
        {
            var existingAppointment = ListOfAppointment.FirstOrDefault(x => x.AppointmentId == updatedAppointment.AppointmentId);

            if (existingAppointment == null)
            {
                Console.WriteLine("Appointment not found!");
                return;
            }

            // Update linked data
            existingAppointment.PatientId = updatedAppointment.PatientId;
            existingAppointment.DoctorId = updatedAppointment.DoctorId;
            existingAppointment.Patient = updatedAppointment.Patient;
            existingAppointment.Doctor = updatedAppointment.Doctor;
            existingAppointment.AppointmentDate = updatedAppointment.AppointmentDate;
            existingAppointment.Reason = updatedAppointment.Reason;

            Console.WriteLine("Appointment updated successfully.");
        }

        public List<Appointment> ViewAllAppointment()
        {
            return ListOfAppointment.OrderBy(x => x.AppointmentId).ToList();
        }
    }
}
