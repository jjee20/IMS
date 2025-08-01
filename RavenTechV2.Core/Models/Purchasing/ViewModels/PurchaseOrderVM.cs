using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Purchasing.ViewModels;
public class PurchaseOrderVM
{
    public int PurchaseOrderId { get; set; }
    public string PurchaseOrderNumber { get; set; }
    public string Vendor { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public ICollection<PurchaseOrderLineVM> PurchaseOrderLines { get; set; }
}
