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
        public int BillId { get; set; }
        public string BillName { get; set; }
        [Display(Name = "Bill Type")]
        public string BillType { get; set; }
        public string PurchaseOrder { get; set; }
        public string VendorDONumber { get; set; }
        public string VendorInvoiceNumber { get; set; }
        public DateTimeOffset BillDate { get; set; }
        public DateTimeOffset BillDueDate { get; set; }
    }
}
