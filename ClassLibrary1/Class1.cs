using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Class1
    {
        static string constr = "data source=DARSHAN\\SQLEXPRESS;initial catalog = sixseptclass;integrated security = true";

        public void DisplayEmployees()
        {
            DataTable dt = ExecuteData("Select * from emp");

            if (dt.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("================================");
                Console.WriteLine("DATABASE RECORDS");
                Console.WriteLine("================================");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["eno"].ToString() + " " + row["empname"].ToString() + " " + row["sal"].ToString());
                }

                Console.Write("============================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.Write("No employee found in the database table!!!");
                Console.Write(Environment.NewLine);

            }


        }

        public void AddNewEmployee()
        {
            string eno = string.Empty;
            string empname = string.Empty;
            string sal = string.Empty;


            Console.WriteLine("INSERT NEW EMPLOYEE :");
            Console.WriteLine("Enter Empno");
            eno = Console.ReadLine();

            Console.WriteLine("Enter EmpName :");
            empname = Console.ReadLine();

            Console.WriteLine("Enter salary :");
            sal = Console.ReadLine();


            ExecuteCommand(string.Format("Insert into emp(eno,empname,sal)values('{0}','{1}','{2}')", eno, empname, sal));

        }


        public static DataTable ExecuteData(string query)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    SqlDataAdapter da =new SqlDataAdapter(sqlcmd);
                    da.Fill(result);//It Executes the DML Queries
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return result;
        }



        public bool ExecuteCommand(string query)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    sqlcmd.ExecuteNonQuery();       //It Executes the DML Queries
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
            return true;
        }

        public void EditEmployee()
        {
            string eno = string.Empty;
            string empname = string.Empty;
            string sal = string.Empty;


            Console.WriteLine("EDIT EXISTING EMPLOYEE :");
            Console.WriteLine("Enter Empno");
            eno = Console.ReadLine();

            Console.WriteLine("Enter EmpName :");
            empname = Console.ReadLine();

            Console.WriteLine("Enter salary :");
            sal = Console.ReadLine();


            ExecuteCommand(string.Format("Update emp set empname='{0}',sal='{1}' where eno='{2}'",empname, sal, eno));

        }

        public void DeleteEmployee()
        {
            string eno = string.Empty;

            Console.WriteLine("DELETE EXISTING EMPLOYEE :");

            Console.WriteLine("Enter Empno");
            eno = Console.ReadLine();

            ExecuteCommand(string.Format("delete from emp where eno='{0}'", eno));
            Console.Write("Employee details deleted from the database" + Environment.NewLine);

        }



    }
}


