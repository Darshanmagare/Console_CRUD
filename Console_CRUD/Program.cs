using System;
using DAL;

namespace Console_CRUD
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Class1 c = new Class1();
            c.DisplayEmployees();
            c.AddNewEmployee();
            c.DisplayEmployees();
            c.EditEmployee();
            c.DisplayEmployees();
            c.DeleteEmployee();
            c.DisplayEmployees();
            
           //c.ExecuteCommand();

        }
    }

}    