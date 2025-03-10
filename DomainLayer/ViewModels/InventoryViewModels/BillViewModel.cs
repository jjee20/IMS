using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class BillViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int BillId { get; set; }
        [Display(Name = "Bill / Invoice #")]
        public string BillName { get; set; }
        [Display(Name = "Bill Type")]
        public string BillType { get; set; }
        [Display(Name = "GRN")]
        public string GoodsReceivedNote { get; set; }
        [Display(Name = "Vendor Delivery Order #")]
        public string VendorDONumber { get; set; }
        [Display(Name = "Vendor Bill / Invoice #")]
        public string VendorInvoiceNumber { get; set; }
        [Display(Name = "Bill Date")]
        public DateTimeOffset BillDate { get; set; }
        [Display(Name = "Bill Due Date")]
        public DateTimeOffset BillDueDate { get; set; }
    }
}
