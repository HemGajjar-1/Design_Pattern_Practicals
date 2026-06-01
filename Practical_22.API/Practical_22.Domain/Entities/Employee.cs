using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Department { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
