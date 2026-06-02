using AutoMapper;
using Practical_23.DAL.UnitOfWork;
using Practical_23.Domain.DTOs;
using Practical_23.Domain.Entities;
using Practical_23.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            employee.JoiningDate = DateTime.Now;
            employee.Status = true;
            employee.IsDeleted = false;

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<EmployeeResponseDto>(employee);
        }
        public async Task<EmployeeResponseDto?> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(dto.Id);
            if(employee == null)
            {
                return null;
            }
            _mapper.Map(dto, employee);
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<EmployeeResponseDto>(employee);
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if(employee == null)
            {
                return false;
            }
            employee.IsDeleted = true;
            employee.Status = false;
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<EmployeeResponseDto>> GetEmployeesAsync(int? id)
        {
            var employees = new List<Employee>();
            if(id.HasValue)
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id.Value);
                if(employee != null)
                {
                    employees.Add(employee);
                }
            }
            else
            {
                employees = (await _unitOfWork.Employees.GetAllAsync()).ToList();
            }
            return _mapper.Map<IEnumerable<EmployeeResponseDto>>(employees);
        }
    }
}
