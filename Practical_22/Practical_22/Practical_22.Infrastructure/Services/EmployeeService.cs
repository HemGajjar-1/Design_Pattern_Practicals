using Microsoft.EntityFrameworkCore;
using Practical_22.Application.DTOs;
using Practical_22.Application.Interfaces;
using Practical_22.Domain.Entities;
using Practical_22.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerService _logger;

        //Deferred Loading
        private static Lazy<EmployeeService>? _instance;
        public static EmployeeService GetInstance(ApplicationDbContext context,ILoggerService logger)
        {
            _instance ??= new Lazy<EmployeeService>(() => new EmployeeService(context, logger));
            return _instance.Value;
        }
        private EmployeeService(ApplicationDbContext context, ILoggerService logger) 
        {
            _context = context;
            _logger = logger;
        }
        public async Task CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            Employee employee = new Employee
            {
                Name = dto.Name,
                Salary = dto.Salary,
                Department = dto.Department,
                EmailId = dto.EmailId,
                JoiningDate = DateTime.Now,
                Status = true
            };
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            _logger.Log($"Employee Created : {employee.Name}");
        }
        public async Task UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            Employee? employee = await _context.Employees.FindAsync(dto.Id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Name = dto.Name;
            employee.Salary = dto.Salary;
            employee.Department = dto.Department;
            employee.EmailId = dto.EmailId;

            await _context.SaveChangesAsync();
            _logger.Log($"Employee Updated : {employee.Id}");
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Status = false;
            await _context.SaveChangesAsync();
            _logger.Log($"Employee Deactivated : {employee.Id}");
        }
        public async Task<List<EmployeeDto>> GetEmployeesAsync(int? id)
        {
            IQueryable<Employee> query = _context.Employees;
            query = query.Where(x => x.Status == true);
            if (id.HasValue)
            {
                query = query.Where(x => x.Id == id.Value);
            }
            List<EmployeeDto> employees = await query.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary,
                Department = x.Department,
                EmailId = x.EmailId,
                JoiningDate = x.JoiningDate,
                Status = x.Status
            }).ToListAsync();
            _logger.Log("Employee Data Fetched");
            return employees;
        }


    }
}
