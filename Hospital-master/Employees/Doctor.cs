using HospitalLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Employees
{
    [Serializable]
    public abstract class Doctor : Employee, IDoctor
    {
        public string GMCNumber { get; protected set; }

        public string Speciality { get; protected set; }

        public List<bool> Duties { get; protected set; }

        public Doctor(string name, string surname, string idNumber, string username, string password, string newGMC) :
            base(name, surname, idNumber, username, password)
        {
            this.GMCNumber = newGMC;
            this.Speciality = GetType().Name;
            this.Duties = new List<bool>();

            for (int i = 0; i < 31; i++)
            {
                Duties.Add(false); // for now, whole schedule is empty .
            }
        }

        public void AddDuty(int dayIndex)
        {
            try
            {
                Duties[dayIndex] = true; // index is set to be declared as a worday for current employee
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public void ChangeGMCNumber(string newGMCNumber)
        {
            this.GMCNumber = newGMCNumber;
        }

        public void ChangeSpeciality(string newSpeciality)
        {
            this.Speciality = newSpeciality;
        }

        public void RemoveDuty(int dayIndex)
        {
            try
            {
                Duties[dayIndex] = false; // index is NOT set to be declared as a worday for current employee
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
