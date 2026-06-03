using Microsoft.EntityFrameworkCore;
using Practical_22.Application.Interfaces.Repositories;
using Practical_22.Domain.Entities;
using Practical_22.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.EmailId == email);
        }
    }
}
