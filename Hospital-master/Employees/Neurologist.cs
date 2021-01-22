using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Employees
{
    [Serializable]
    public sealed class Neurologist : Doctor
    {
        public Neurologist(string gMCNumber, string name, string surname, string idNumber, string username, 
            string password) : base(gMCNumber, name, surname, idNumber, username, password)
        {
        }
    }
}
