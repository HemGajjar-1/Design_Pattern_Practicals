using AutoMapper;
using Practical_26.Application.Interfaces.Repository;
using Practical_26.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Interfaces.Service
{
    public class EmployeeQueryService :IEmployeeQueryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeQueryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeQueryDto>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.EmployeeQueries.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeQueryDto>>(employees);
        }
        public async Task<EmployeeQueryDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeQueries.GetByIdAsync(id);
            if(employee == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeQueryDto>(employee);
        }
    }
}
