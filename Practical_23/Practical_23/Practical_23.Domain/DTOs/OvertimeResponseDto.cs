using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.Domain.DTOs
{
    public class OvertimeResponseDto
    {
        public int EmployeeId { get; set; }
        public string Department { get; set; } = string.Empty;
        public int Hours { get; set; }
        public decimal OvertimePay { get; set; }
    }
}
