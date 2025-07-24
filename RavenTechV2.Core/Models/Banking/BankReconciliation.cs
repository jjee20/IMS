using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Banking;
public class BankReconciliation
{
    [Key]
    public int BankReconciliationId { get; set; }
    public int BankAccountId { get; set; }
    [ForeignKey("BankAccountId")]
    public BankAccount BankAccount { get; set; }
    public DateTime StatementStart { get; set; }
    public DateTime StatementEnd { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal ClosingBalance { get; set; }
    public ICollection<BankTransaction> MatchedTransactions { get; set; }
    public bool IsReconciled { get; set; }
}