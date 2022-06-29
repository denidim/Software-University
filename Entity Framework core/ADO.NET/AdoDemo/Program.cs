using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;

            SqlConnection connection = new SqlConnection("Server=.;Database=SoftUni;User Id=sa;Password=mssqlDB1;");
            connection.Open();

            List<Employee> employees = new List<Employee>();
            using (connection)
            {
                //string name = "Guy";
                string name = "' or 1=1 --";

                SqlCommand cmd = 
                    new SqlCommand(@"select FirstName, LastName, Salary from Employees where FirstName = @name", connection);

                cmd.Parameters.AddWithValue("name", name);

                using (cmd)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee()
                            {
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["lastName"],
                                Salary = (decimal)reader["Salary"]
                            });
                            //Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} - {reader["Salary"]}");
                        }
                    }
                }
            }
            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Salary}");
            }
        }
    }
}
