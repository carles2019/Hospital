using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Interfaces
{
    public interface INurse : IEmployee
    {
        List<bool> Duties { get; }
        void AddDuty(int dayIndex);
        void RemoveDuty(int dayIndex);
    }
}
