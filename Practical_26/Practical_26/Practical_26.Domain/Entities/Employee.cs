using Practical_26.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public string EmailId { get; set; }

        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}
