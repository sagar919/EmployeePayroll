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

       

        public List<Employee> EmployeeList() 
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            { 
                SqlCommand command = new SqlCommand("spNewShowEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;


                sqlConnection.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                //List<Employee> employeeDetails = new List<Employee>();
                /*Parent parent = new Parent()*/;
                
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
                        Department = dataReader["Department"].ToString()

                        //Department = (Departments)dataReader["Department"]

                    };


                    employees.Add(employee);
                    //parent.Employee.Add(employee);
                    //parent.Departments.Add(departments);


                }
                sqlConnection.Close();
                return employees;
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

        public bool InsertEmployee(Parent employee)
        {
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                string DepartmentList = string.Empty;
                if (employee.isHr == true)
                {
                    DepartmentList = DepartmentList + "Hr,";
                }
                 if (employee.isFinance == true)
                {
                    DepartmentList = DepartmentList + "Finance,";
                }
                 if (employee.isSales == true)
                {
                    DepartmentList = DepartmentList + "Sales,";
                }
                 if (employee.isOthers == true)
                {
                    DepartmentList = DepartmentList + "Others";
                }


                SqlCommand command = new SqlCommand("spInsertEmployee", sqlConnection);

                command.CommandType = CommandType.StoredProcedure;
                //employee.Department = "Hr";
                
                command.Parameters.AddWithValue("Name", employee.Name);               
                command.Parameters.AddWithValue("ProfileImage", employee.ProfileImage);
                command.Parameters.AddWithValue("Gender", employee.Gender);               
                command.Parameters.AddWithValue("Salary", employee.Salary);               
                command.Parameters.AddWithValue("StartDate", employee.StartDate);   
                
                command.Parameters.AddWithValue("Note", employee.Description);
                command.Parameters.AddWithValue("departList", DepartmentList);



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

        public bool DeleteEmployee(Parent employee)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
               
                SqlCommand command = new SqlCommand("spDeleteEmployeeById", sqlConnection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Id", employee.Id);
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

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }




      
        public string RegisterUser(UserDetails user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();

                return result;
            }
        }

      
        public string ValidateLogin(UserDetails user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();

                return result;
            }
        }
    }
}
