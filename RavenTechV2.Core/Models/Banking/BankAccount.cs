using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Banking;
public class BankAccount
{
    [Key]
    public int BankAccountId { get; set; }
    [Required]
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public string Branch { get; set; }
    public decimal CurrentBalance { get; set; }
    public bool IsActive { get; set; }
}
