using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Interfaces
{
    public interface IEmployee
    {
        string Name { get; }
        string Surname { get; }
        string IdNumber { get; }
        string Username { get; }
        string Password { get; }

        void ChangeName(string newName);
        void ChangeSurname(string newSurname);
        void ChangeIdNumber(string newIdNumber);
        void ChangeUsername(string newUserName);
        void ChangePassword(string newPassword);
        void Info();
    }
}
