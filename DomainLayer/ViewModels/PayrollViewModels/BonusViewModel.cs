using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Enums;
using DomainLayer.Models.Accounts;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class BonusViewModel
    {
        public int BonusId { get; set; } // Primary Key
        public string Employee { get; set; } // Navigation Property
        public string BonusType { get; set; } // E.g., "Performance Bonus", "Holiday Bonus"
        public double Amount { get; set; } // Bonus amount
        public string Description { get; set; } // Optional: Additional details
        public DateTime DateGranted { get; set; } // Date the bonus is granted
        public string IsOneTime { get; set; } // True for one-time bonuses, false for recurring bonuses
    }
}
