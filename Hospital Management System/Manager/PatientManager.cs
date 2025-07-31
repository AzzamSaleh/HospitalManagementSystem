using Hospital_Management_System.Interfaces;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    internal class PatientManager : IPatient
    {
        // Implements for IPatient (Interface) ==> (CRUD) Operation



        //When a user performs a CRUD operation, where does it happen?
        //So We need a ==> List<>(list that contains patient objects).


        public List<Patient> ListOfPatient {  get; set; }

        public PatientManager() {

            //To give a initial Value for ListOfPatient

            ListOfPatient=new List<Patient>();
        }



        //implements for (CRUD) Operation:

        public void AddPatient(Patient patient)
        {

            //To Solve a problem If the user try to Add a Exist Patient Id:             
            //checks if a Patient with the same PatientId already exists in the list before adding a new Patient.

            if (ListOfPatient.Any(x => x.PatientId == patient.PatientId))
            {
                Console.WriteLine("Patient Id already Exist");
                return;
            }

            ListOfPatient.Add(patient);
            Console.WriteLine("Patient added successfully.");
           
            
        }


        public void Delete(int id)
        {
            
            var patient =ListOfPatient.FirstOrDefault(x=>x.PatientId == id);//Return Null If not found Patient Id.

            //If statement If the user Enter Wrong Patient Id.
            if (patient != null)
            {
                ListOfPatient.Remove(patient);
                Console.WriteLine($"Patient '{patient.PatientName}' deleted.");
            }
            else{
           
                Console.WriteLine("Patient Not Found!");

            }

        }


        public void UpdatePatient(Patient patient)
        {
            var existingPatient = ListOfPatient.FirstOrDefault(x => x.PatientId == patient.PatientId);

            if (existingPatient != null)
            {
                existingPatient.PatientName = patient.PatientName;
                existingPatient.PatientAge = patient.PatientAge;
                existingPatient.PatientGender = patient.PatientGender;
                existingPatient.PatientCondition = patient.PatientCondition;

                Console.WriteLine("Patient updated successfully.");
            }
            else
            {
                Console.WriteLine("Patient Not Found!");
            }

           
        }


        public List<Patient> ViewAllPatients()
        {
            return ListOfPatient.OrderBy(x => x.PatientId).ToList();
        }
    }
}
