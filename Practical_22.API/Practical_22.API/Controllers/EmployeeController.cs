using Microsoft.AspNetCore.Mvc;
using Practical_22.Application.DTOs;
using Practical_22.Application.Interfaces;

namespace Practical_22.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
            CreateEmployeeDto dto)
        {
            await _employeeService.CreateEmployeeAsync(dto);

            return Ok("Employee Created Successfully");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(
            UpdateEmployeeDto dto)
        {
            await _employeeService.UpdateEmployeeAsync(dto);

            return Ok("Employee Updated Successfully");
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);

            return Ok("Employee Deactivated Successfully");
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees(int? id)
        {
            var employees =
                await _employeeService.GetEmployeesAsync(id);

            return Ok(employees);
        }
    }
}
