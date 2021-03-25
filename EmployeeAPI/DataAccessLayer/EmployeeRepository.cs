using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDataContext context;
        public EmployeeRepository(EmployeeDataContext _context)
        {
            context = _context;
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return context.Employees.Find(id);
        }

        public Employee AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public byte UpdateEmployee(Guid id, UpdateEmployeeModel employee)
        {
            if (id != employee.Id)
            {
                return 3;
            }

            Employee _employee = context.Employees.Find(id);
            if (_employee != null)
            {
                if (employee.Name != null)
                    _employee.Name = employee.Name;
                if (employee.Address != null)
                    _employee.Address = employee.Address;
                if (employee.Phone != 0)
                    _employee.Phone = employee.Phone;
                if (employee.Country != null)
                    _employee.Country = employee.Country;
                if (employee.Zip != 0)
                    _employee.Zip = employee.Zip;
            }
            else
                return 2;
            context.Entry(_employee).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.Employees.Any(e => e.Id == id))
                {
                    return 2;
                }
                else
                {
                    throw;
                }
            }

            return 1;
        }

        public Employee DeleteEmployee(Guid id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee == null)
            {
                return null;
            }

            context.Employees.Remove(employee);
            context.SaveChanges();

            return employee;
        }
    }
}