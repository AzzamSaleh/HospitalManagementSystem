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
    internal class DoctorMenu //class to handle all doctor-related user interactions.
    {


       



        //Dependency Injection
        private readonly DoctorManager _doctorManager;

        public DoctorMenu(DoctorManager doctorManager)
        {
            _doctorManager = doctorManager;
        }


        //Helpers |Safe int input
        private int GetSafeIntInput(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }






        //Show Doctor Menu:
        public void ShowDoctorMenu()
        {
            while (true)
            {

                //Doctor Menu:
                Console.Clear();
                Console.WriteLine("--- Doctor Menu ---");
                Console.WriteLine("1) Add Doctor");
                Console.WriteLine("2) View All Doctors");
                Console.WriteLine("3) Update Doctor");
                Console.WriteLine("4) Delete Doctor");
                Console.WriteLine("5) Back to Main Menu");
                Console.Write("Select an option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid option. Press Enter to try again...");
                    Console.ReadLine();
                    continue;
                }


                switch (option)
                {

                    case 1://Add Doctor

                        var doctorObj = new Doctor();

                        // Collect Doctor information 
                        Console.Write("Enter Doctor ID: ");
                        doctorObj.DoctorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        doctorObj.DoctorName = Console.ReadLine();

                        Console.Write("Enter Specialty: ");
                        doctorObj.DoctorSpecialty = Console.ReadLine();

                        Console.Write("Enter Phone Number: ");
                        doctorObj.DoctorPhoneNumber = Console.ReadLine();


                        _doctorManager.AddDoctor(doctorObj);

                        break;



                    case 2://View All Doctors


                        var doctors = _doctorManager.ViewAllDoctor();//the return type from view methods is a list.
                        if (doctors.Count == 0)
                        {

                            Console.WriteLine("No doctors found.");
                            break;// return early
                        }


                        Console.WriteLine($"Total Doctors Found: {doctors.Count}");
                        foreach (var doctor in doctors)
                            Console.WriteLine(doctor); // uses ToString()
                        break;





                    case 3://Update Doctor

                        int docId = GetSafeIntInput("Enter Doctor ID to update: ");
                        var existingDoctor = _doctorManager.ViewAllDoctor()
                            .FirstOrDefault(d => d.DoctorId == docId);

                        if (existingDoctor == null)
                        {
                            Console.WriteLine("Doctor not found!");
                            break;
                        }

                        var updatedDoctor = new Doctor { DoctorId = docId };


                        // Collect updated docctor info
                        Console.Write("Enter new Name: ");
                        updatedDoctor.DoctorName = Console.ReadLine();

                        Console.Write("Enter new Specialty: ");
                        updatedDoctor.DoctorSpecialty = Console.ReadLine();

                        Console.Write("Enter new Phone Number: ");
                        updatedDoctor.DoctorPhoneNumber = Console.ReadLine();

                        _doctorManager.UpdateDoctor(updatedDoctor);
                        break;



                    case 4://Delete Doctor
                        int idToDelete = GetSafeIntInput("Enter Doctor ID to delete: ");
                        _doctorManager.Delete(idToDelete);
                        break;


                    case 5:
                        //Stop executing the current method (ShowDoctorMenu)
                        //and go back to where it was called from.
                        Console.WriteLine("Returning to Main Menu...");
                        return;// Go back to the main menu
                               

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;

                }


                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            
        }

    }
}
