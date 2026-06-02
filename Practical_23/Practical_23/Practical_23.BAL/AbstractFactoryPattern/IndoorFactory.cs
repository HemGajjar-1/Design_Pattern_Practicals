using Practical_23.BAL.FactoryPattern;
using Practical_23.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.AbstractFactoryPattern
{
    public class IndoorFactory : IDepartmentFactory
    {
        public IOvertimeCalculator Create(DepartmentType department)
        {
            return department switch
            {
                DepartmentType.IT => new ITOvertimeCalculator(),
                DepartmentType.HR => new HROvertimeCalculator(),
                DepartmentType.Admin => new AdminOvertimeCalculator(),
                _ => throw new Exception("Invalid indoor department")
            };
        }
    }
}
