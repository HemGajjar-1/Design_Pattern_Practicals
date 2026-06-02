using Practical_26.DAL.Repositories;
using Practical_26.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Interfaces.Repository
{
    public interface IUnitOfWork 
    {
        IGenericCommandRepository<Employee> EmployeeCommands { get; }
        IGenericQueryRepository<Employee> EmployeeQueries { get; }
        Task<int> SaveChangesAsync();
    }
}
