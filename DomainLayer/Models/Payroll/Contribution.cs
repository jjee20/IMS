using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Contribution : BaseEntity
    { 
        [Key]
        public int ContributionId { get; set; } // Primary Key
        public ContributionType ContributionType { get; set; } // Example: "SSS", "Pag-IBIG", "PhilHealth"
        public double EmployeeRate { get; set; } // Percentage or fixed amount
        public double EmployerRate { get; set; } // Percentage or fixed amount
        public double MinimumLimit { get; set; } // Max amount (if applicable)
        public double MaximumLimit { get; set; } // Max amount (if applicable)
    }

}
