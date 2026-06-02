using Practical_26.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Interfaces.Service
{
    public interface IEmployeeQueryService
    {
        Task<IEnumerable<EmployeeQueryDto>> GetAllEmployeesAsync();
        Task<EmployeeQueryDto?> GetEmployeeByIdAsync(int id);
    }
}
