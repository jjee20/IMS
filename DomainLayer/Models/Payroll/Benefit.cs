using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Benefit
    {
        [Key]
        public int BenefitId { get; set; } // Primary Key
        public string Name { get; set; } // Example: "Health Insurance", "Transportation"
        public double Amount { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(PayrollId))]

        public int PayrollId { get; set; } // Foreign Key
        public Payroll Payroll { get; set; }
    }

}
