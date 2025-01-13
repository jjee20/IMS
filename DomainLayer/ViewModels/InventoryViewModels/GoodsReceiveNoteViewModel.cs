using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class GoodsReceiveNoteViewModel
    {
        [Display(Name = "Id")]
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "GRN #")]
        public string GoodsReceivedNoteName { get; set; }
        [Display(Name = "Purchase Order #")]
        public string PurchaseOrder { get; set; }
        [Display(Name = "GRN Date")]
        public DateTimeOffset GRNDate { get; set; }
        [Display(Name = "Vendor Delivery Order #")]
        public string VendorDONumber { get; set; }
        [Display(Name = "Vendor Bill / Invoice #")]
        public string VendorInvoiceNumber { get; set; }
        public string Warehouse { get; set; }
        public bool IsFullReceive { get; set; }
    }
}
