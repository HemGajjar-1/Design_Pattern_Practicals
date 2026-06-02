using Practical_26.DAL.Data;
using Practical_26.DAL.Repositories;
using Practical_26.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Interfaces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericCommandRepository<Employee> EmployeeCommands { get; }
        public IGenericQueryRepository<Employee> EmployeeQueries { get; }
        public UnitOfWork(ApplicationDbContext context,IGenericCommandRepository<Employee> employeeCommands,IGenericQueryRepository<Employee> employeeQueries)
        {
            _context = context;
            EmployeeCommands = employeeCommands;
            EmployeeQueries = employeeQueries;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
