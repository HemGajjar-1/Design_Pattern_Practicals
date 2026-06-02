using Microsoft.AspNetCore.Mvc;
using Practical_26.Application.Commands;
using Practical_26.Application.Interfaces.Service;
using Practical_26.Domain.Entities;

namespace Practical_26.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommandService _commandService;
        private readonly IEmployeeQueryService _queryService;

        public EmployeeController(IEmployeeCommandService commandService,IEmployeeQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            int employeeId = await _commandService.CreateEmployeeAsync(command);
            return Ok(new
            {
                Message = "Employee created successfully",
                EmployeeId = employeeId
            });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand command)
        {
            var result = await _commandService.UpdateEmployeeAsync(command);
            if(!result)
            {
                return NotFound(new
                {
                    Message = "Employee Not Found"
                });
            }
            return Ok(new
            {
                Message = "Employee updated successfully"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _commandService.DeleteEmployeeAsync(id);
            if(!result)
            {
                return NotFound(new
                {
                    Message = "Employee Not Found"
                });
            }
            return Ok(new
            {
                Message = "Employee deleted successfully"
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee(int? id)
        {
            if(id==null)
            {
                var employees = await _queryService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            var employee = await _queryService.GetEmployeeByIdAsync(id.Value);
            if(employee == null)
            {
                return NotFound(new
                {
                    Message = "Employee Not Found"
                });
            }
            return Ok(employee);
        }
    }
}
