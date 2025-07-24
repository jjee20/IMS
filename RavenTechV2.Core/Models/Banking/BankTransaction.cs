using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Banking;
public class BankTransaction
{
    [Key]
    public int BankTransactionId { get; set; }
    public int BankAccountId { get; set; }
    [ForeignKey("BankAccountId")]
    public BankAccount BankAccount { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public BankTransactionType TransactionType { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
}
