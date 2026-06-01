using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practical_25.Application.Features.Employees.Command.CreateEmployee;
using Practical_25.Application.Features.Employees.Command.DeleteEmployee;
using Practical_25.Application.Features.Employees.Command.UpdateEmployee;
using Practical_25.Application.Features.Employees.Queries.GetEmployee;

namespace Practical_25.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand
            {
                Id = id
            });
            return Ok(new
            {
                Message = "Employee deleted successfully",
                Success = result
            });
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            var result = await _mediator.Send(new GetEmployeeQuery
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
