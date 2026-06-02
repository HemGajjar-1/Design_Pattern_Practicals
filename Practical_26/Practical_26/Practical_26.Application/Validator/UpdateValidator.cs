using FluentValidation;
using Practical_26.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Validator
{
    public class UpdateValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Valid Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("Salary must be greater than 0");
            RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("DepartmentId must be greater than 0");
            RuleFor(x => x.EmailId).NotEmpty().EmailAddress().WithMessage("Valid email is required");
        }
    }
}
