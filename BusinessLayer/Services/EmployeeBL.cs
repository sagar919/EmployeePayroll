using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private IEmployeeRL _employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this._employeeRL = employeeRL;
        }

        public bool DeleteEmployee(Parent employee)
        {
            try
            {
                return this._employeeRL.DeleteEmployee(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Employee> EmployeeList()
        {
            try
            {
                return this._employeeRL.EmployeeList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool InsertEmployee(Parent employee )
        {
            try
            {
                return this._employeeRL.InsertEmployee(employee);
            }
            catch(Exception ex)
            {

                throw;
            }
        }

        public string RegisterUser(UserDetails user)
        {
            try
            {
                return this._employeeRL.RegisterUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string ValidateLogin(UserDetails user)
        {
            try
            {
                return this._employeeRL.ValidateLogin(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Employee> EmployeeListNew()
        {
            try
            {
                return this._employeeRL.EmployeeListNew();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
