using MediatR;
using Practical_25.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Application.Features.Employees.Command.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler: IRequestHandler<DeleteEmployeeCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request,CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Status = false;
            employee.IsDeleted = true;
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }   
    }
}
