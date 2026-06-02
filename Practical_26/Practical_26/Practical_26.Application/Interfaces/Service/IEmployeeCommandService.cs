using Practical_26.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Interfaces.Service
{
    public interface IEmployeeCommandService
    {
        Task<int> CreateEmployeeAsync(CreateEmployeeCommand command);
        Task<bool> UpdateEmployeeAsync(UpdateEmployeeCommand command);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
