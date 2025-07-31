using Hospital_Management_System.Interfaces;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Manager
{
    internal class DoctorManager : IDoctor // (logic implementation) // (implements IDoctor ==>(CRUD) Operation)
    {


        public List<Doctor> ListOfDoctor { get; set; }
        // (list that contains Doctor objects).
        public DoctorManager()
        {

            //To give a initial Value for ListOfDoctor

            ListOfDoctor = new List<Doctor>();
        }





        //implements for (CRUD) Operation:
        public void AddDoctor(Doctor doctor)
        {
            
            //checks if a Doctor with the same DoctorId already exists in the list before adding a new Doctor.

            if (ListOfDoctor.Any(x => x.DoctorId == doctor.DoctorId))
            {
                Console.WriteLine("Doctor ID already exists!");
                return;
            }

            ListOfDoctor.Add(doctor);
            Console.WriteLine("Doctor added successfully.");

        }



        public void Delete(int id)
        {

            var doctor = ListOfDoctor.FirstOrDefault(x => x.DoctorId == id);//Return Null If not found Doctor Id.

            //If statement ==> If the user Enter Wrong DoctorId.
            if (doctor != null)
            {
                ListOfDoctor.Remove(doctor);
                Console.WriteLine($"Doctor '{doctor.DoctorName}' deleted.");
            }
            else
            {

                Console.WriteLine("Doctor Not Found!");

            }
        }

        public void UpdateDoctor(Doctor doctor)
        {

            var existingDoctor = ListOfDoctor.FirstOrDefault(x => x.DoctorId == doctor.DoctorId);

            if (existingDoctor == null)
            {
                Console.WriteLine("Doctor Not Found!");
                return;
            }

            existingDoctor.DoctorName = doctor.DoctorName;
            existingDoctor.DoctorSpecialty = doctor.DoctorSpecialty;
            existingDoctor.DoctorPhoneNumber = doctor.DoctorPhoneNumber;

            Console.WriteLine("Doctor updated successfully.");
        }


        public List<Doctor> ViewAllDoctor()
        {
            return ListOfDoctor.OrderBy(x => x.DoctorId).ToList(); ;
        }
    }
}
