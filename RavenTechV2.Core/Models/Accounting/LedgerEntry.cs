using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Accounting;
public class LedgerEntry
{
    [Key]
    public int LedgerEntryId { get; set; }
    [Required]
    public int ChartOfAccountId { get; set; }
    [ForeignKey("ChartOfAccountId")]
    public ChartOfAccount Account { get; set; }
    [Required]
    public decimal Debit { get; set; }
    [Required]
    public decimal Credit { get; set; }
    public DateTime EntryDate { get; set; }
    public string Description { get; set; }
    // Optional links for traceability
    public string SourceType { get; set; }
    public int? SourceId { get; set; }
}
