using HospitalLibrary.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HospitalLibrary.Interfaces
{
    [Serializable]
    public class Hospital
    {
        public List<Employee> employeeList { get; private set; }

        // needed 2 methods for serialiazation and deserialization 
 
        private readonly string SerializationPath;
        private readonly string SerializationFile;
        public string HospitalName { get; }

        public Hospital()
        {

        }

        public Hospital(string newHospitalName)
        {
            this.HospitalName = newHospitalName;
            this.SerializationPath = $"";
            this.SerializationFile = $"{GetType().Name}_{HospitalName}.txt";

            if (File.Exists(SerializationPath + SerializationFile))
            {
                this.employeeList = Deserialize().employeeList;
                return;
            }
            this.employeeList = new List<Employee>();
            Serialize();
        }

        public void Add(Employee newEmp)
        {
            if (!EmployeeExists(newEmp.IdNumber) && !EmployeeExists(newEmp.Name, newEmp.Surname))
            {
                employeeList.Add(newEmp);
                Serialize();
                return;
            }

            throw new Exception("There is such employee in system already.");  // maybe another custom exception
        }


        public void Remove(Employee newEmp)
        {
            if (EmployeeExists(newEmp.IdNumber) && EmployeeExists(newEmp.Name, newEmp.Surname))
            {
                employeeList.Remove(newEmp);
                Serialize();
                return;
            }

            throw new Exception("There is NO such employee in system yet.");
        }

        public bool EmployeeExists(string IdNumber)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].IdNumber == IdNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EmployeeExists(string Name, string FamilyName)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Name == Name && employeeList[i].Surname == FamilyName)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckCreditDataExists(string username, string password)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Username == username && employeeList[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckCreditDataExists(string username, string password, out Employee employee)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Username == username && employeeList[i].Password == password)
                {
                    employee = employeeList[i];
                    return true;
                }
            }

            throw new Exception("There is no such a user");
        }

        private void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(SerializationPath + SerializationFile, FileMode.Create,
                FileAccess.Write))
            {
                formatter.Serialize(stream, this);
            }
        }

        private Hospital Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(SerializationPath + SerializationFile, FileMode.Open,
                FileAccess.Read))
            {
                stream.Position = 0;
                return (Hospital)formatter.Deserialize(stream);
            }
        }

        public void PrintEmployees()
        {
            foreach (var item in employeeList)
            {
                item.Info();
            }
        }
    }
}
