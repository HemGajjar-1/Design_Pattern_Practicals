using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.FactoryPattern
{
    public class SalesOvertimeCalculator : IOvertimeCalculator
    {
        public decimal CalculateOvertime(int hours)
        {
            return hours * 100;
        }
    }
}
