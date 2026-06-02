using Practical_23.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.AbstractFactoryPattern
{
    public static class FactoryProducer
    {
        public static IDepartmentFactory GetFactory(DepartmentType department)
        {
            return department switch
            {

                DepartmentType.IT or
                DepartmentType.HR or
                DepartmentType.Admin => new IndoorFactory(),

                DepartmentType.Sales or
                DepartmentType.OnSite => new OutdoorFactory(),

                _ => throw new Exception("Invalid department")
            };
        }
    }
}
