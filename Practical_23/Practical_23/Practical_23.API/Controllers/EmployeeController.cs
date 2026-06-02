using Microsoft.AspNetCore.Mvc;
using Practical_23.Domain.Common;
using Practical_23.Domain.DTOs;
using Practical_23.Domain.Interfaces;

namespace Practical_23.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
        {
            var result = await _employeeService.CreateEmployeeAsync(dto);
            var response = new ApiResponse<EmployeeResponseDto>
            {
                Success = true,
                Message = "Employee created successfully",
                Data = result
            };
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto dto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(dto);
            if(result ==null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Employee not found"
                });
            }
            return Ok(new ApiResponse<EmployeeResponseDto>
            {
                Success = true,
                Message = "Employee updated successfully",
                Data = result
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (!result)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Employee Not Found"
                });
            }
            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Employee deleted successfully"
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees(int? id)
        {
            var result = await _employeeService.GetEmployeesAsync(id);
            return Ok(new ApiResponse<IEnumerable<EmployeeResponseDto>>
            {
                Success = true,
                Message = "Employee fetched successfully",
                Data = result
            }); 
        }
    }
}
