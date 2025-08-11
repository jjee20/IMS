using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Purchasing;
public class Bill
{
    [Key]
    public int BillId { get; set; }
    public string BillNumber { get; set; }
    public int VendorId { get; set; }
    [ForeignKey("VendorId")]
    public Vendor Vendor { get; set; }
    public int? PurchaseOrderId { get; set; }
    [ForeignKey("PurchaseOrderId")]
    public PurchaseOrder PurchaseOrder { get; set; }
    public decimal Amount { get; set; }
    public DateTime BillDate { get; set; }
    public DateTime DueDate { get; set; }
    public BillStatus Status { get; set; }
    public decimal TotalPaid { get; set; }

    [NotMapped]
    public decimal Balance => Amount - TotalPaid;

    [NotMapped]
    public bool IsOverpaid => TotalPaid > Amount;
}
