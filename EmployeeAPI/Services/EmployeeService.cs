using EmployeeAPI.Exceptions;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        public EmployeeService(IEmployeeRepository _repository)
        {
            repository = _repository;
        }

        public Employee AddEmployee(Employee employee)
        {
            if (repository.GetEmployeeById(employee.Id) == null)
                return repository.AddEmployee(employee);
            throw new EmployeeAlreadyExistsException($"Employee with ID: {employee.Id} already exists!");
        }

        public Employee DeleteEmployee(Guid id)
        {
            if (repository.GetEmployeeById(id) != null)
                return repository.DeleteEmployee(id);
            throw new EmployeeNotFoundException($"Employee with ID: {id} does not exist!");
        }

        public List<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }

        public Employee GetEmployeeById(Guid id)
        {
            Employee employee = repository.GetEmployeeById(id);
            if (employee != null)
                return employee;
            throw new EmployeeNotFoundException($"Employee with ID: {id} does not exist!");
        }

        public bool UpdateEmployee(Guid id, UpdateEmployeeModel employee)
        {
            byte result = repository.UpdateEmployee(id, employee);
            if (result == 1)
                return true;
            else if (result == 2)
                throw new EmployeeNotFoundException($"Employee with ID: {id} does not exist!");
            return false;
        }
    }
}