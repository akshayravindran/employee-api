using EmployeeAPI.Exceptions;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeesController(IEmployeeService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error occurred!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(service.GetEmployeeById(id));
            }
            catch (EmployeeNotFoundException enf)
            {
                return NotFound(enf.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error occurred");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                return StatusCode(201, service.AddEmployee(employee));
            }
            catch (EmployeeAlreadyExistsException eae)
            {
                return Conflict(eae.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error occurred");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateEmployeeModel employee)
        {
            try
            {
                if (service.UpdateEmployee(id, employee))
                    return Ok();
                return BadRequest();
            }
            catch (EmployeeNotFoundException enf)
            {
                return NotFound(enf.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error occurred");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                return Ok(service.DeleteEmployee(id));
            }
            catch (EmployeeNotFoundException enf)
            {
                return NotFound(enf.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error occurred");
            }
        }
    }
}