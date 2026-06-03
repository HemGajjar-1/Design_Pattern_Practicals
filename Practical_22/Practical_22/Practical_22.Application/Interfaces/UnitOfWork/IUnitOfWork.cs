using Practical_22.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        Task<int> SaveChangesAsync();
    }
}
