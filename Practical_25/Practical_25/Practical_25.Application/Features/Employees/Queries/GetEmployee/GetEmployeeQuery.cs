using MediatR;
using Practical_25.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<IEnumerable<EmployeeDto>>
    {
        public int? Id { get; set; }
    }
}
