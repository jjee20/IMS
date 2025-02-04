using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Benefit : BaseEntity
    {
        [Key]
        public int BenefitId { get; set; } // Primary Key
        public BenefitType BenefitType { get; set; } // Example: "Health Insurance", "Transportation"
        public double Amount { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }
        public string Other { get; set; }
    }

}
