using MediatR;
using Practical_25.Application.DTOs;
using Practical_25.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Application.Features.Employees.Command.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public Department DepartmentId { get; set; }

        public string EmailId { get; set; } = string.Empty;
    }
}
