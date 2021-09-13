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
    }
}
