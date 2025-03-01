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
    public class ChartOfAccount
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required]
        public AccountCategory Category { get; set; } // Assets, Liabilities, etc.

        public int? ParentAccountId { get; set; } // For sub-accounts
        [ForeignKey(nameof(ParentAccountId))]
        public virtual ChartOfAccount ParentAccount { get; set; } 

        public decimal Balance { get; set; } = 0;

        public override string ToString()
        {
            return $"{AccountNumber} - {AccountName} ({Category})";
        }
    }
}
