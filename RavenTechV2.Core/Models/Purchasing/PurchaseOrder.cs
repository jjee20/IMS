using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Purchasing;
public class PurchaseOrder
{
    [Key]
    public int PurchaseOrderId { get; set; }
    [Required]
    public string PurchaseOrderNumber { get; set; }
    [Required]
    public string VendorId { get; set; }
    [ForeignKey("VendorId")]
    public Vendor Vendor { get; set; }
    public DateTime OrderDate { get; set; }
    public PurchaseOrderStatus Status { get; set; }
    public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
}
