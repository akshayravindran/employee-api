using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.DataAccessLayer
{
    public class EmployeeDataContext : DbContext
    {
        public EmployeeDataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}