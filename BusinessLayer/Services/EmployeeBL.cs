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

        public bool InsertEmployee(Employee employee )
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
    }
}
