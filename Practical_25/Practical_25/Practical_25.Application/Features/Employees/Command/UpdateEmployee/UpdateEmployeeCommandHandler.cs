using MediatR;
using Practical_25.Application.DTOs;
using Practical_25.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Application.Features.Employees.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request,CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Name = request.Name;
            employee.Salary = request.Salary;
            employee.DepartmentId = request.DepartmentId;
            employee.EmailId = request.EmailId;

            _unitOfWork.Employees.Update(employee);

            await _unitOfWork.SaveChangesAsync();

            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                EmailId = employee.EmailId
            };
        }
    }
}
