using HospitalLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Employees
{
    [Serializable]
    public sealed class Administrator : Employee
    {
        public Administrator(string name, string surname, string idNumber, string username, string password) :
            base(name, surname, idNumber, username, password)
        {
        }

        public override void ShowMenu()
        {
            base.ShowMenu();
            Console.WriteLine("Type 2 - edit the data of each worker ");
            Console.WriteLine("Type 3 - Add new users ");
            Console.WriteLine("Type 4 - Quit");
        }
    }
}
