using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        List<Employee> EmployeeList();

        bool InsertEmployee(Parent employee);

        bool DeleteEmployee(Parent employee);

        string RegisterUser(UserDetails user);

        string ValidateLogin(UserDetails user);

        List<Employee> EmployeeListNew();
    }
}

