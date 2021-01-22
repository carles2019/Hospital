using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Interfaces;
using HospitalLibrary.Employees;

namespace HospitalControlPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hs = new Hospital("WSBAsylum");
            hs.Add(new Administrator("admin", "admin", "admin", "admin", "admin"));
            Employee emp;
            Console.WriteLine($"Welcome to hospital : {hs.HospitalName}");

            while (true)
            {
                try
                {
                    Console.Write("Enter Username : ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password : ");
                    string password = Console.ReadLine();
                    hs.CheckCreditDataExists(username, password, out emp);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool IsAdministrator = emp is Administrator;

            switch (IsAdministrator)
            {
                case true:
                    Console.WriteLine("Is admin");
                    emp.ShowMenu();
                    int n;
                    n = int.Parse(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Users : ");
                            hs.PrintEmployees();
                            break;
                        case 2:
                            Console.WriteLine("Editing : ");
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Provide speciality : ");
                                    string[] specialities = new string[] { "administrator" };
                                    string speciality = Console.ReadLine().ToLower();
                                    if (!specialities.Contains(speciality))
                                    {
                                        throw new Exception("There is no such speciality");
                                    }
                                    Console.Write("Enter first name : ");
                                    string firstname = Console.ReadLine();
                                    
                                    Console.Write("Enter last name : ");
                                    string lastname = Console.ReadLine();
                                    Console.Write("Enter ID : ");
                                    string idNumber = Console.ReadLine();
                                    Console.Write("Enter Username : ");
                                    string username = Console.ReadLine();
                                    Console.Write("Enter Password : ");
                                    string password = Console.ReadLine();

                                    if (speciality == "administrator")
                                    {
                                        Console.Write("Enter new first name : ");
                                        string newfirstname = Console.ReadLine();
                                        emp.ChangeName(newfirstname);
                                        Console.Write("Enter new last name : ");
                                        string newlastname = Console.ReadLine();
                                        emp.ChangeSurname(newlastname);
                                        Console.Write("Enter new ID : ");
                                        string newidNumber = Console.ReadLine();
                                        emp.ChangeIdNumber(newidNumber);
                                        Console.Write("Enter new Username : ");
                                        string newusername = Console.ReadLine();
                                        emp.ChangeUsername(newusername);
                                        Console.Write("Enter new Password : ");
                                        string newpassword = Console.ReadLine();
                                        emp.ChangePassword(newpassword);
                                        break;
                                    }
                                    else
                                    {
                                        throw new Exception("There is no such speciality  1111111111111");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("Adding : ");
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Provide speciality : ");
                                    string[] specialities = new string[] { "adminstrator", "doctor","nurse","urologist","cardiologist","laryngologist","neuorologist" };
                                    string speciality = Console.ReadLine().ToLower();
                                    if (!specialities.Contains(speciality))
                                    {
                                        throw new Exception("There is no such speciality");
                                    }
                                    Console.Write("Enter first name : ");
                                    string firstname = Console.ReadLine();
                                    Console.Write("Enter last name : ");
                                    string lastname = Console.ReadLine();
                                    Console.Write("Enter ID : ");
                                    string idNumber = Console.ReadLine();
                                    Console.Write("Enter Username : ");
                                    string username = Console.ReadLine();
                                    Console.Write("Enter Password : ");
                                    string password = Console.ReadLine();

                                    if (speciality == "nurse")
                                    {
                                        hs.Add(new Nurse(firstname, lastname, idNumber, username, password));
                                        break;
                                    }

                                    else if (speciality == "administrator")
                                    {
                                        hs.Add(new Administrator(firstname, lastname, idNumber, username, password));
                                        break;
                                    }

                                    else if (speciality == "urologist" || speciality == "cardiologist" || speciality == "laryngologist" || speciality == "neurologist")
                                    {
                                        Console.Write("Provide GMC : ");
                                        string GMC = Console.ReadLine();

                                        switch (speciality)
                                        {
                                            case "urologist":
                                                hs.Add(new Urologist(GMC, firstname, lastname, idNumber, username, password));
                                                break;
                                            case "cardiologist":
                                                hs.Add(new Cardiologist(GMC, firstname, lastname, idNumber, username, password));
                                                break;
                                            case "laryngologist":
                                                hs.Add(new Laryngologist(GMC, firstname, lastname, idNumber, username, password));
                                                break;
                                            case "neurologist":
                                                hs.Add(new Neurologist(GMC, firstname, lastname, idNumber, username, password));
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    else
                                    {
                                        throw new Exception("There is no such speciality");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Exit");
                            break;
                    }
                    //hs.Choose();
                    break;
                case false:
                    Console.WriteLine("Is not admin");
                    emp.ShowMenu();
                    //hs.PrintEmployees();
                    break;
            }
            /*switch(IsAdministrator)
            {
                case 1:

            }*/
        }
    }
}
