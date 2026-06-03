using AutoMapper;
using Practical_22.Application.DTOs;
using Practical_22.Application.Interfaces;
using Practical_22.Application.Interfaces.UnitOfWork;
using Practical_22.Domain.Entities;

namespace Practical_22.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public EmployeeService(
          IUnitOfWork unitOfWork,
          ILoggerService logger,
          IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateEmployeeAsync(
            CreateEmployeeDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);

            employee.JoiningDate = DateTime.Now;

            employee.Status = true;

            await _unitOfWork
                .Employees
                .AddAsync(employee);

            await _unitOfWork
                .SaveChangesAsync();

            _logger.Log(
                $"Employee Created : {employee.Name}");
        }

        public async Task UpdateEmployeeAsync(
            UpdateEmployeeDto dto)
        {
            Employee? employee =
                await _unitOfWork
                .Employees
                .GetByIdAsync(dto.Id);

            if (employee == null)
            {
                throw new Exception(
                    "Employee not found");
            }

            _mapper.Map(dto, employee);

            _unitOfWork
                .Employees
                .Update(employee);

            await _unitOfWork
                .SaveChangesAsync();

            _logger.Log(
                $"Employee Updated : {employee.Id}");
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            Employee? employee =
                await _unitOfWork
                .Employees
                .GetByIdAsync(id);

            if (employee == null)
            {
                throw new Exception(
                    "Employee not found");
            }

            employee.Status = false;

            _unitOfWork
                .Employees
                .Update(employee);

            await _unitOfWork
                .SaveChangesAsync();

            _logger.Log(
                $"Employee Deactivated : {employee.Id}");
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync(
            int? id)
        {
            IEnumerable<Employee> employees;

            if (id.HasValue)
            {
                Employee? employee =
                    await _unitOfWork
                    .Employees
                    .GetByIdAsync(id.Value);

                employees = employee != null
                    ? new List<Employee> { employee }
                    : new List<Employee>();
            }
            else
            {
                employees =
                    await _unitOfWork
                    .Employees
                    .GetAllAsync();
            }

            List<EmployeeDto> result = _mapper.Map<List<EmployeeDto>>(employees);

            _logger.Log(
                "Employee Data Fetched");

            return result;
        }
    }
}