using Microsoft.EntityFrameworkCore;
using Practical_24.Application.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_24.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await _context.Employees.Where(e=> !e.IsDeleted).ToListAsync();
        }
    }
}
