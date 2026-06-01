using Practical_24.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_24.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<string> CreateAsync(EmployeeDto dto);
        Task<string> UpdateAsync(EmployeeDto dto);
        Task<string> DeleteAsync(int id);
        Task<string> DeactivateAsync(int id);
    }
}
