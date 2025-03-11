using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class InvoiceViewModel
    {
        [Display(Name = "Id")]
        public int InvoiceId { get; set; }
        [Display(Name = "Invoice #")]
        public string InvoiceName { get; set; }
        [Display(Name = "Invoice Type")]
        public string InvoiceType { get; set; }
        public string SalesOrder { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTimeOffset InvoiceDate { get; set; }
        [Display(Name = "Due Date")]
        public DateTimeOffset InvoiceDueDate { get; set; }
    }
}
