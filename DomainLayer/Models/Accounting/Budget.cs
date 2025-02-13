using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        [Required]
        public int ChartOfAccountID { get; set; } // Links transaction to an account in the Chart of Accounts

        [ForeignKey("ChartOfAccountID")]
        public virtual ChartOfAccount Account { get; set; } // Navigation property

        [Required]
        public decimal BudgetAmount { get; set; }

        public decimal SpentAmount { get; set; } = 0;

        public decimal RemainingAmount => BudgetAmount - SpentAmount;
    }
}
