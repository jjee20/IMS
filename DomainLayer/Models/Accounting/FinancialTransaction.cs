using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting
{
    public class FinancialTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int ChartOfAccountID { get; set; } // Links transaction to an account in the Chart of Accounts

        [ForeignKey("ChartOfAccountID")]
        public virtual ChartOfAccount Account { get; set; } // Navigation property

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public string Description { get; set; }
    }
}
