using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Interfaces
{
    internal interface IPatient
    {
        //(CRUD) Operation on Patient:
        //(Add,View All,Update,Delete)

        void AddPatient(Patient patient);

        List<Patient> ViewAllPatients();

        void UpdatePatient(Patient patient);

        void Delete(int id);
    }
}
