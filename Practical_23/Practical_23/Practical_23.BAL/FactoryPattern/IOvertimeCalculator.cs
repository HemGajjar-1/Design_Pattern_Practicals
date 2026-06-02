using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.BAL.FactoryPattern
{
    public interface IOvertimeCalculator
    {
        decimal CalculateOvertime(int hours);
    }
}
