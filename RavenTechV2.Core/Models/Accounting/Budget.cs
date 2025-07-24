using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Accounting;
public class Budget
{
    [Key]
    public int BudgetId { get; set; }
    [Required]
    public int ChartOfAccountId { get; set; }
    [ForeignKey("ChartOfAccountId")]
    public ChartOfAccount Account { get; set; }
    public decimal BudgetAmount { get; set; }
    public decimal SpentAmount { get; set; }
    public decimal RemainingAmount => BudgetAmount - SpentAmount;
}
