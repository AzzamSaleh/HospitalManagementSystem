using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    internal class Patient
    {

        //Patient properties:
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender  { get; set; }
        public string PatientCondition { get; set; }



        //printing in menus || Easy Way
        public override string ToString()
        {
            return $"ID: {PatientId} | Name: {PatientName} | Age: {PatientAge} | Gender: {PatientGender} | Condition: {PatientCondition}";
        }

    }
}
