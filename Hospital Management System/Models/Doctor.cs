using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    internal class Doctor
    {
        //Doctor properties:
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialty { get; set; }
        public string DoctorPhoneNumber { get; set; }//It might contain +, -, or spaces


        // For Easy printing in menus
        public override string ToString()
        {
            return $"ID: {DoctorId} | Name: {DoctorName} | Specialty: {DoctorSpecialty} | Phone: {DoctorPhoneNumber}";
        }
    }
}
