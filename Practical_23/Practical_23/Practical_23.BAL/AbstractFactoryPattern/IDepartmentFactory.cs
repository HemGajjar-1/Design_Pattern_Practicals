using Practical_23.BAL.FactoryPattern;
using Practical_23.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.AbstractFactoryPattern
{
    public interface IDepartmentFactory
    {
        IOvertimeCalculator Create(DepartmentType department);
    }
}
