using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Interfaces
{
    internal interface IDoctor
    {
        //(CRUD) Operation:

        void AddDoctor(Doctor doctor);

        List<Doctor> ViewAllDoctor();

        void UpdateDoctor(Doctor doctor);

        void Delete(int id);
    }
}
