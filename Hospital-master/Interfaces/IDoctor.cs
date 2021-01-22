using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Interfaces
{
    public interface IDoctor
    {
        string GMCNumber { get; }
        string Speciality { get; }
        List<bool> Duties { get; }

        void ChangeSpeciality(string newSpeciality);
        void ChangeGMCNumber(string newGMCNumber);
        void AddDuty(int dayIndex);
        void RemoveDuty(int dayIndex);

    }
}
