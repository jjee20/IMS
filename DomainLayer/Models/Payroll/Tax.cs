using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; } // Primary Key
        public double MinimumSalary { get; set; }
        public double MaximumSalary { get; set; }
        public double TaxRate { get; set; } // In percentage

        public ICollection<Payroll> Payrolls { get; set; } // Navigation Property
    }

}
