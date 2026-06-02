using Microsoft.AspNetCore.Mvc;
using Practical_23.BAL.Services;
using Practical_23.Domain.Common;
using Practical_23.Domain.DTOs;
using Practical_23.Domain.Interfaces;
using System.Net.WebSockets;

namespace Practical_23.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OvertimeController : ControllerBase
    {
        private readonly IOvertimeService _overtimeService;
        public OvertimeController(IOvertimeService overtimeService)
        {
            _overtimeService = overtimeService;
        }
        [HttpGet("factory")]
        public async Task<IActionResult> GetOvertimeUsingFactory(int employeeId,int hours)
        {
            var result = await _overtimeService.GetOvertimeUsingFactoryAsync(employeeId, hours);
            if(result == null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Employee not found"
                });
            }
            return Ok(new ApiResponse<OvertimeResponseDto>
            {
                Success = true,
                Message = "Overtime calculated successfully",
                Data = result
            });
        }
        [HttpGet("abstract-factory")]
        public async Task<IActionResult> GetOvertimeUsingAbstractFactory(int employeeId,int hours)
        {
            var result = await _overtimeService.GetOvertimeUsingAbstractFactoryAsync(employeeId, hours);
            if(result == null)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Employee not found."
                });
            }
            return Ok(new ApiResponse<OvertimeResponseDto>
            {
                Success = true,
                Message = "Overtime calculated successfully",
                Data = result
            });
        }   

    }
}
