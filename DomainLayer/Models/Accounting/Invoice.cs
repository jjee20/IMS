using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Accounting
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } // Navigation property
        [Required]
        public int ChartOfAccountID { get; set; } // Links transaction to an account in the Chart of Accounts

        [ForeignKey("ChartOfAccountID")]
        public virtual ChartOfAccount Account { get; set; } // Navigation property

        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public InvoiceStatus Status { get; set; }
    }
}
