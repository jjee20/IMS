using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting
{
    public class LedgerEntry
    {
        [Key]
        public int LedgerEntryId { get; set; }

        [Required]
        public int ChartOfAccountID { get; set; } // Links transaction to an account in the Chart of Accounts

        [ForeignKey("ChartOfAccountID")]
        public virtual ChartOfAccount Account { get; set; } // Navigation property

        [Required]
        public decimal Debit { get; set; } = 0;

        [Required]
        public decimal Credit { get; set; } = 0;

        [Required]
        public DateTime EntryDate { get; set; } = DateTime.Now;

        public string Description { get; set; }
    }
}
