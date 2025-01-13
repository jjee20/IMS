using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Enums;

namespace DomainLayer.Models.Payroll
{
    public class Bonus
    {
        [Key]
        public int BonusId { get; set; } // Primary Key

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key to Employee
        public Employee Employee { get; set; } // Navigation Property

        [Required]
        [MaxLength(100)]
        public BonusType BonusType { get; set; } // E.g., "Performance Bonus", "Holiday Bonus"

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; } // Bonus amount

        public string Description { get; set; } // Optional: Additional details

        [Required]
        public DateTime DateGranted { get; set; } // Date the bonus is granted

        public bool IsOneTime { get; set; } = true; // True for one-time bonuses, false for recurring bonuses
    }
}
