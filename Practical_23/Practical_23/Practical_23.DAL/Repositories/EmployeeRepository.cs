using Microsoft.EntityFrameworkCore;
using Practical_23.DAL.Data;
using Practical_23.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {     
        }
    }
}
