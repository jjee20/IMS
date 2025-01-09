using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class JobPosition
    {
        [Key]
        public int JobPositionId { get; set; } // Primary Key
        public string Title { get; set; }
        public double Salary { get; set; } // Base Salary
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; } // Navigation Property
    }

}
