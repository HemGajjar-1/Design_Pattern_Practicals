using MediatR;
using Practical_25.Application.DTOs;
using Practical_25.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery,IEnumerable<EmployeeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEmployeeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeeQuery request,CancellationToken cancellationToken)
        {
            if (request.Id.HasValue)
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id.Value);
                if(employee == null)
                {
                    throw new Exception("Employee not found");
                }
                return new List<EmployeeDto>
                {
                    new EmployeeDto
                    {
                         Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                        DepartmentId = employee.DepartmentId,
                        EmailId = employee.EmailId
                    }
                };
            }
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return employees.Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                EmailId = employee.EmailId
            });
        }
    }
}
