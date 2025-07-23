using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Accounting;
public class ChartOfAccount
{
    [Key]
    public int AccountId { get; set; }
    [Required, StringLength(50)]
    public string AccountNumber { get; set; }
    [Required, StringLength(100)]
    public string AccountName { get; set; }
    [Required]
    public AccountCategory Category { get; set; }
    public int? ParentAccountId { get; set; }
    [ForeignKey("ParentAccountId")]
    public ChartOfAccount ParentAccount { get; set; }
    public decimal Balance { get; set; }
    public ICollection<LedgerEntry> LedgerEntries { get; set; }
}
