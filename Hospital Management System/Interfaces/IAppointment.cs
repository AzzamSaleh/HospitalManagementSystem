using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Interfaces
{
    internal interface IAppointment
    {
        //(CRUD) Operation:
        void AddAppointment(Appointment appointment);

        List<Appointment> ViewAllAppointment();

        void UpdateAppointment(Appointment updatedAppointment);

        void Delete(int id);

    }
}
