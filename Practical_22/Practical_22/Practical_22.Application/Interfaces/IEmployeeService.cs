using Practical_22.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeDto dto);
        Task UpdateEmployeeAsync(UpdateEmployeeDto dto);
        Task DeleteEmployeeAsync(int id);
        Task<List<EmployeeDto>> GetEmployeesAsync(int? id);
    }
}
    