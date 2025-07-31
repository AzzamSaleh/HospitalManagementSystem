using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    internal class Appointment
    {
        //Appointment properties:

        public int AppointmentId { get; set; }

        //Appointment needs both PatientId and DoctorId
        public int PatientId { get; set; }
        public int DoctorId { get; set; }


        //Patient and Doctor objects: for easy access to full details like names, phone numbers, etc.
        //define navigation properties 
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }


        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }

        public override string ToString()
        {
            string patientName = Patient?.PatientName ?? "Unknown";
            string doctorName = Doctor?.DoctorName ?? "Unknown";
            return $"ID: {AppointmentId} | Patient: {patientName} | Doctor: {doctorName} | Date: {AppointmentDate:yyyy-MM-dd HH:mm} | Reason: {Reason}";
        }
    }
}
