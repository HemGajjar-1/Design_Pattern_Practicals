using Practical_23.BAL.AbstractFactoryPattern;
using Practical_23.BAL.FactoryPattern;
using Practical_23.DAL.UnitOfWork;
using Practical_23.Domain.DTOs;
using Practical_23.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.Services
{
    public class OvertimeService : IOvertimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OvertimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OvertimeResponseDto?> GetOvertimeUsingFactoryAsync(int employeeId,int hours)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
            if(employee == null)
            {
                return null;
            }
            var calculator = DepartmentFactory.Create(employee.DepartmentId);
            var overtimePay = calculator.CalculateOvertime(hours);
            return new OvertimeResponseDto
            {
                EmployeeId = employee.Id,
                Department = employee.DepartmentId.ToString(),
                Hours = hours,
                OvertimePay = overtimePay
            };
        }
        public async Task<OvertimeResponseDto?> GetOvertimeUsingAbstractFactoryAsync(int employeeId, int hours)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
            if(employee == null)
            {
                return null;
            }
            var factory = FactoryProducer.GetFactory(employee.DepartmentId);
            var calculator = factory.Create(employee.DepartmentId);
            var overtimePay = calculator.CalculateOvertime(hours);
            return new OvertimeResponseDto
            {
                EmployeeId = employee.Id,
                Department = employee.DepartmentId.ToString(),
                Hours = hours,
                OvertimePay = overtimePay
            };
        }
    }
}
