using Practical_23.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_23.Domain.DTOs
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DepartmentType DepartmentId { get; set; }

        public string EmailId { get; set; } = string.Empty;
    }
}
