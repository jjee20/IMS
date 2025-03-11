using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class PurchaseOrder 
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Order Number")]
        public string PurchaseOrderName { get; set; }
        [Display(Name = "Branch")]
        [ForeignKey("BranchId")]
        public int BranchId { get; set; }
        [Display(Name = "Vendor")]
        [ForeignKey("VendorId")]
        public int VendorId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        [Display(Name = "Purchase Type")]
        [ForeignKey("PurchaseTypeId")]
        public int PurchaseTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();
        public virtual Branch Branch { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual PurchaseType PurchaseType { get; set; }

        public virtual IEnumerable<GoodsReceivedNote> GoodsReceivedNote { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual IEnumerable<PaymentVoucher> PaymentVoucher { get; set; }
    }
}
