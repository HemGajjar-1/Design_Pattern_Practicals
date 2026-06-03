using Practical_22.Application.Interfaces.Repositories;
using Practical_22.Application.Interfaces.UnitOfWork;
using Practical_22.Infrastructure.Data;
using Practical_22.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IEmployeeRepository Employees { get; }
        public UnitOfWork(ApplicationDbContext context,IEmployeeRepository employeerepository)
        {
            _context = context;
            Employees = employeerepository;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
