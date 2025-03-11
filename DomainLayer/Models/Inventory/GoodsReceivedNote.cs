using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class GoodsReceivedNote 
    {
        [Key]
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "GRN Number")]
        public string GoodsReceivedNoteName { get; set; }
        [Display(Name = "Purchase Order")]
        [ForeignKey("PurchaseOrderId")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "GRN Date")]
        public DateTimeOffset GRNDate { get; set; }
        [Display(Name = "Vendor Delivery Order #")]
        public string VendorDONumber { get; set; }
        [Display(Name = "Vendor Bill / Invoice #")]
        public string VendorInvoiceNumber { get; set; }
        [Display(Name = "Warehouse")]
        [ForeignKey("WarehouseId")]
        public int WarehouseId { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Full Receive")]
        public bool IsFullReceive { get; set; } = true;

        public virtual Warehouse Warehouse { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
