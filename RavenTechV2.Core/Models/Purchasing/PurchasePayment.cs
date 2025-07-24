using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Purchasing;
public class PurchasePayment
{
    [Key]
    public int PaymentId { get; set; }
    public int BillId { get; set; }
    [ForeignKey("BillId")]
    public Bill Bill { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
}
