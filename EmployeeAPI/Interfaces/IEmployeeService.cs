using EmployeeAPI.Models;
using System;
using System.Collections.Generic;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeService
    {
        Employee AddEmployee(Employee employee);
        Employee DeleteEmployee(Guid id);
        Employee GetEmployeeById(Guid id);
        List<Employee> GetEmployees();
        bool UpdateEmployee(Guid id, UpdateEmployeeModel employee);
    }
}