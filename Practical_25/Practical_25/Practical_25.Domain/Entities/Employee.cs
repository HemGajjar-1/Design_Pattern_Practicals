using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_25.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Department DepartmentId { get; set; }
        public string EmailId { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
