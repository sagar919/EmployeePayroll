using CommonLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace RepositoryLayer.Services
{

    public class EmployeeRL : IEmployeeRL
    {
        string connectionString = @"Data Source=IN-J20N0F3;Initial Catalog=EmployeePayrollDB;Integrated Security=True";
        public Parent EmployeeList()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand("spShowEmployees", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;


                sqlConnection.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                //List<Employee> employeeDetails = new List<Employee>();
                Parent parent = new Parent();
                
                while (dataReader.Read())
                {
                    Employee employee = new Employee()
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Name = dataReader["Name"].ToString(),
                        ProfileImage = dataReader["ProfileImage"].ToString(),
                        Gender = dataReader["Gender"].ToString(),
                        Salary = Convert.ToInt32(dataReader["Salary"]),
                        StartDate = Convert.ToDateTime(dataReader["StartDate"]),
                        Description = dataReader["Notes"].ToString(),
                        //Department = dataReader["Department"].ToString()
                       
                        //Department = (Departments)dataReader["Department"]

                    };

                    Departments departments = new Departments();
                    {
                        departments.Id = Convert.ToInt32(dataReader["Id"]);
                        departments.Department = dataReader["Department"].ToString();
                        departments.IsCheck = Convert.ToBoolean(dataReader["IsCheck"]);

                    };

                    parent.Employee.Add(employee);
                    parent.Departments.Add(departments);


                }
                sqlConnection.Close();
                return parent;
            }

                
            catch (Exception ex)
            {
                Console.WriteLine($"Message={ex.Message} and stack trace-{ex.StackTrace}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }

            
        }

        public bool InsertEmployee(Employee employee)
        {
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand("spInsertEmployee", sqlConnection);

                command.CommandType = CommandType.StoredProcedure;
                //employee.Department = "Hr";
                
                command.Parameters.AddWithValue("Name", employee.Name);               
                command.Parameters.AddWithValue("ProfileImage", employee.ProfileImage);
                command.Parameters.AddWithValue("Gender", employee.Gender);               
                command.Parameters.AddWithValue("Salary", employee.Salary);               
                command.Parameters.AddWithValue("StartDate", employee.StartDate);   
                command.Parameters.AddWithValue("departList", employee.Department);
                command.Parameters.AddWithValue("Notes", employee.Description);



                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
