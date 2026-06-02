using Practical_23.BAL.FactoryPattern;
using Practical_23.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.AbstractFactoryPattern
{
    public class OutdoorFactory : IDepartmentFactory
    {
        public IOvertimeCalculator Create(DepartmentType department)
        {
            return department switch
            { 
                DepartmentType.Sales => new SalesOvertimeCalculator(),
                DepartmentType.OnSite => new OnSiteOvertimeCalculator(),
                _ => throw new Exception("Invalid outdoor factory")
            };
        }
    }
}
