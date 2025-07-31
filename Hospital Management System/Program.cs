using Hospital_Management_System.Manager;
using Hospital_Management_System.Menu_Manager;
using Hospital_Management_System.Services;
using System;
using Newtonsoft.Json;
using System.IO;
namespace Hospital_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HOSPITAL MANAGEMENT SYSTEM PROJECT:




            // Create shared managers
            var patientManager = new PatientManager();
            var doctorManager = new DoctorManager();
            var appointmentManager = new AppointmentManager();

            // Load data when program starts
            DataStorage.LoadAllData(patientManager, doctorManager, appointmentManager);



            // Inject dependencies
            var patientMenu = new PatientMenu(patientManager);
            var doctorMenu = new DoctorMenu(doctorManager);
            var appointmentMenu = new AppointmentMenu(appointmentManager, patientManager, doctorManager);

            try
            {
                while (true)
                {
                    //Main menu:
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("    HOSPITAL MANAGEMENT SYSTEM");
                    Console.WriteLine("========================================");


                    Console.WriteLine("1) Manage Patients");
                    Console.WriteLine("2) Manage Doctors");
                    Console.WriteLine("3) Manage Appointments ");


                    Console.WriteLine("4) Exit");
                    Console.Write("Select an option: ");



                    if (!int.TryParse(Console.ReadLine(), out int option))
                    {
                        Console.WriteLine("Invalid input. Press Enter to try again...");
                        Console.ReadLine();
                        continue;
                    }

                    switch (option)
                    {

                        case 1://Manage Patients:

                            // Open & Handle Patient Management Menu
                            patientMenu.ShowPatientMenu();

                            break;



                        case 2://Manage Doctors:

                            // Open & Handle Doctor Management Menu
                            doctorMenu.ShowDoctorMenu();
                            break;



                        case 3://Manage Appointments:

                            // Open & Handle Appointments Management Menu
                            appointmentMenu.ShowAppointmentMenu();
                            break;



                        case 4:

                            Console.WriteLine("Saving data and exiting...");
                            // Save all data before exit
                            DataStorage.SaveAllData(patientManager, doctorManager, appointmentManager);
                            Console.WriteLine("Data saved successfully. Goodbye!");
                            Console.ReadLine();
                            return;


                        default:

                            Console.WriteLine("Invalid input. Press Enter to try again.");
                            Console.ReadLine();
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }
}

