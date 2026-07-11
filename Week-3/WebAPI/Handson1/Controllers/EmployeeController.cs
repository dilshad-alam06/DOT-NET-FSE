using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Handson1.Models;
using System.Collections.Generic;

namespace Handson1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // GET: api/employee
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetStandard()
        {
            var employees = GetStandardEmployeeList();
            return Ok(employees);
        }

        // POST: api/employee
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            // In a real scenario, you would add the employee to a data store.
            // Here we simply return the created employee.
            return CreatedAtAction(nameof(GetStandard), new { id = employee.Id }, employee);
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // In a real scenario, you would update the employee in the data store.
            // Here we simply assume success.
            return NoContent();
        }

        // Private helper method to provide a standard list of employees
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 100,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET Core" }
                    },
                    DateOfBirth = new System.DateTime(1990,1,1)
                },
                new Employee
                {
                    Id = 101,
                    Name = "Jane Smith",
                    Salary = 55000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Recruiting" }
                    },
                    DateOfBirth = new System.DateTime(1992,5,15)
                }
            };
        }
    }
}
