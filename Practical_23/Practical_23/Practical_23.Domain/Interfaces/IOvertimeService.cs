using Practical_23.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.Domain.Interfaces
{
    public interface IOvertimeService
    {
        Task<OvertimeResponseDto?> GetOvertimeUsingFactoryAsync(int employeeId, int hours);
        Task<OvertimeResponseDto?> GetOvertimeUsingAbstractFactoryAsync(int employeeId, int hours);
        
    }
}
