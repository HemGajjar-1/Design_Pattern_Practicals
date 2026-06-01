using MediatR;
using Practical_25.Application.DTOs;
using Practical_25.Application.Interfaces;
using Practical_25.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Application.Features.Employees.Command.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand,EmployeeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request , CancellationToken cancellationToken)
        {
            var existingEmployee = await _unitOfWork.Employees.GetEmployeeByEmailAsync(request.EmailId);
            if(existingEmployee != null)
            {
                throw new Exception("Employee with this email Id already exists");
            }
            var employee = new Employee
            {
                Name = request.Name,
                Salary = request.Salary,
                DepartmentId = request.DepartmentId,
                EmailId = request.EmailId,
                JoiningDate = DateTime.Now,
                Status = true,
                IsDeleted = false
            };
            await _unitOfWork.Employees.AddAsync(employee);
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
