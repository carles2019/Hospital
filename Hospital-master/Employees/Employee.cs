using HospitalLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Employees
{
    [Serializable]
    public abstract class Employee : IEmployee
    {
        public string Name { get; protected set; }

        public string Surname { get; protected set; }

        public string IdNumber { get; protected set; }

        public string Username { get; protected set; }

        public string Password { get; protected set; }

        public Employee(string name, string surname, string idNumber, string username, string password)
        {
            Name = name;
            Surname = surname;
            IdNumber = idNumber;
            Username = username;
            Password = password;
        }

        public void ChangeIdNumber(string newIdNumber)
        {
            this.IdNumber = newIdNumber;
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        public void ChangePassword(string newPassword)
        {
            this.Password = newPassword;
        }

        public void ChangeSurname(string newSurname)
        {
            this.Surname = newSurname;
        }

        public void ChangeUsername(string newUserName)
        {
            this.Username = newUserName;
        }

        public virtual void Info()
        {
            Console.WriteLine($"{GetType().Name} - {this.Name} {this.Surname} \n{this.IdNumber} \n{this.Username} \n{this.Password}  ");
        }

        public virtual void ShowMenu()
        {
            Console.WriteLine("Type 1 - Display all users on the list : ");
        }
    }
}
