using System;

namespace EmployeeAPI.Exceptions
{
    public class EmployeeAlreadyExistsException : ApplicationException
    {
        public EmployeeAlreadyExistsException() : base() { }
        public EmployeeAlreadyExistsException(string message) : base(message) { }
    }
}