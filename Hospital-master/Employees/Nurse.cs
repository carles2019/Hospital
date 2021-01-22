using HospitalLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Employees
{
    [Serializable]
    public sealed class Nurse : Employee
    {
        public Nurse(string name, string surname, string idNumber, string username, string password) : base(name, surname, idNumber, username, password)
        {
        }
    }
}
