using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Menu_Manager
{
    internal class PatientMenu 
    {    //Organize Patient Operation Menu.//handling user interaction



      


        //Dependency Injection
        private readonly PatientManager _patientManager;

        public PatientMenu(PatientManager patientManager)
        {
            _patientManager = patientManager;
        }


        // Helpers | Safe int input
        private int GetSafeIntInput(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }



        //Show Patient Menu:
        public void ShowPatientMenu()
        {

            while (true)
            {
                //Patient Menu:
                Console.Clear();
                Console.WriteLine("--- Patient Menu ---");
                Console.WriteLine("1) Add Patient");
                Console.WriteLine("2) View All Patients");
                Console.WriteLine("3) Update Patient");
                Console.WriteLine("4) Delete Patient");
                Console.WriteLine("5) Back to Main Menu");
                Console.Write("Select an option: ");


                string input = Console.ReadLine();

                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("Invalid option. Press Enter to try again...");
                    Console.ReadLine();
                    continue;
                }



                switch (option)
                {
                    case 1://Add Patient

                        var patientObj = new Patient();

                        // Collect patient information 
                        Console.Write("Enter Patient ID: ");
                        patientObj.PatientId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        patientObj.PatientName = Console.ReadLine();

                        Console.Write("Enter Age: ");
                        patientObj.PatientAge = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Gender: ");
                        patientObj.PatientGender = Console.ReadLine();

                        Console.Write("Enter Condition: ");
                        patientObj.PatientCondition = Console.ReadLine();


                        _patientManager.AddPatient(patientObj);

                        break;



                    case 2://View All Patients


                        var listOfPatient = _patientManager.ViewAllPatients();//the return type from view methods is a list.
                        if (listOfPatient == null || listOfPatient.Count == 0)
                        {
                            Console.WriteLine("No Patients Found!");
                        }

                        //to know if the list is truly empty.
                        Console.WriteLine($"Total Patients Found: {listOfPatient.Count}");
                        foreach (var item in listOfPatient)
                        {
                            Console.WriteLine($"ID: {item.PatientId} | Name: {item.PatientName} | Age: {item.PatientAge} | Gender: {item.PatientGender} | Condition: {item.PatientCondition}");
                        }


                        break;



                    case 3://Update Patient
                        Console.Write("Enter Patient ID to update: ");
                        var PatientIdToUpdate = Convert.ToInt32(Console.ReadLine());


                        // Check if patient exists or not first
                        var existingPatient = _patientManager.ViewAllPatients().FirstOrDefault(x => x.PatientId == PatientIdToUpdate);

                        if (existingPatient == null)
                        {
                            Console.WriteLine("Patient not found!");
                            break;
                        }

                        var updatedPatient = new Patient { PatientId = PatientIdToUpdate };

                        // Collect updated patient info
                        Console.Write("Enter new Name: ");
                        updatedPatient.PatientName = Console.ReadLine();

                        Console.Write("Enter new Age: ");
                        updatedPatient.PatientAge = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter new Gender: ");
                        updatedPatient.PatientGender = Console.ReadLine();

                        Console.Write("Enter new Condition: ");
                        updatedPatient.PatientCondition = Console.ReadLine();

                        _patientManager.UpdatePatient(updatedPatient);
                        break;




                    case 4://Delete Patient
                        Console.Write("Enter Patient ID to delete: ");

                        var patientId = Convert.ToInt32(Console.ReadLine());
                        _patientManager.Delete(patientId);

                        break;



                    case 5:
                        Console.WriteLine("Returning to Main Menu...");
                        return;// Go back to the main menu


                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        // Console.ReadLine();
                        break;
                }


                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            }

        }
        // Helper for string input
        private string Prompt(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

    }

}
