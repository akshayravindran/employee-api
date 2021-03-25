using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class UpdateEmployeeModel
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
    }
}