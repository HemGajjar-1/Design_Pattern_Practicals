using Practical_23.DAL.GenericRepository;
using Practical_23.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.DAL.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
       
    }
}
