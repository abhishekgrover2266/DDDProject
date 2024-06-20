using DDDProject.Application;
using DDDProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDProject.Controllers
{
    // Example API controller
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> Log;

        public EmployeeController(EmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            Log = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp == null)
            {
                Log.LogError("File Not Found // ");
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var emp = await _employeeService.GetAllEmployeesAsync();

            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertEmployee(Employee emp)
        {
            var empID = await _employeeService.InsertEmployeeAsync(emp);
            return Ok(empID);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest("emp ID mismatch");
            }

            await _employeeService.UpdateEmployeeAsync(emp);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }

}
