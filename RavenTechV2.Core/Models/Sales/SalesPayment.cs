using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales;
public class SalesPayment
{
    [Key]
    public int PaymentId { get; set; }
    public int InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public Invoice Invoice { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    [Required]
    public PaymentType PaymentType { get; set; } 
    public string PaymentReference { get; set; }
    public string Remarks { get; set; }
    public PaymentStatus Status { get; set; }

}
