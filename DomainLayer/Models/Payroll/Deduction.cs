using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Deduction 
    {
        [Key]
        public int DeductionId { get; set; } // Primary Key
        public DeductionType DeductionType { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(EmployeeId))]

        public int EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }
    }

}
