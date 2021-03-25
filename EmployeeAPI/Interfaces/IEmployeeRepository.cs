using EmployeeAPI.Models;
using System;
using System.Collections.Generic;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee AddEmployee(Employee employee);
        Employee DeleteEmployee(Guid id);
        Employee GetEmployeeById(Guid id);
        List<Employee> GetEmployees();
        byte UpdateEmployee(Guid id, UpdateEmployeeModel employee);
    }
}