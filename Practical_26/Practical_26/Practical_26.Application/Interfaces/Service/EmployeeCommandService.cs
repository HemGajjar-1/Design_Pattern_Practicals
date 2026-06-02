using AutoMapper;
using Practical_26.Application.Commands;
using Practical_26.Application.Interfaces.Repository;
using Practical_26.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Interfaces.Service
{
    public class EmployeeCommandService : IEmployeeCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeCommandService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> CreateEmployeeAsync(CreateEmployeeCommand command)
        {
            var employee = _mapper.Map<Employee>(command);
            employee.JoiningDate = DateTime.Now;
            await _unitOfWork.EmployeeCommands.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return employee.Id;
        }
        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeCommand command)
        {
            var employee = await _unitOfWork.EmployeeQueries.GetByIdAsync(command.Id);
            if(employee == null)
            {
                return false;
            }
            _mapper.Map(command, employee);
            employee.UpdatedDate = DateTime.Now;
            _unitOfWork.EmployeeCommands.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeQueries.GetByIdAsync(id);
            if(employee == null)
            {
                return false;
            }
            employee.IsDeleted = true;
            employee.Status = false;
            employee.UpdatedDate = DateTime.Now;

            _unitOfWork.EmployeeCommands.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
