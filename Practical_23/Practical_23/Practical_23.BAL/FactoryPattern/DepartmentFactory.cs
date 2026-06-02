using Practical_23.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.FactoryPattern
{
    public class DepartmentFactory
    {
        public static IOvertimeCalculator Create(DepartmentType department)
        {
            return department switch 
            { 
                DepartmentType.IT => new ITOvertimeCalculator(),
                DepartmentType.HR => new HROvertimeCalculator(),
                DepartmentType.Admin => new AdminOvertimeCalculator(),
                DepartmentType.OnSite => new OnSiteOvertimeCalculator(),
                DepartmentType.Sales => new SalesOvertimeCalculator(),
                _ => throw new Exception("Invalid Department")
            };
        }
    }
}
