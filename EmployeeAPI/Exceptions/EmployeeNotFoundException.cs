using System;

namespace EmployeeAPI.Exceptions
{
    public class EmployeeNotFoundException : ApplicationException
    {
        public EmployeeNotFoundException() : base() { }
        public EmployeeNotFoundException(string message) : base(message) { }
    }
}