using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Application.DTOs
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string Department { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;
    }
}
