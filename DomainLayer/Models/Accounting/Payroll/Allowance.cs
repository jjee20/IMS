using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Enums;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class Allowance
    {
        [Key]
        public int AllowanceId { get; set; } // Primary Key

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key to Employee
        public Employee Employee { get; set; } // Navigation Property

        [Required]
        public AllowanceType AllowanceType { get; set; } // E.g., "Transport", "Housing"

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; } // Allowance amount

        public string Description { get; set; } // Optional: Additional details

        [Required]
        public DateTime StartDate { get; set; } // Date the allowance is granted
        [Required]
        public DateTime EndDate { get; set; } // Date the allowance is granted
    }
}
