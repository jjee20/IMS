using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Invoice 
    {
        [Key]
        public int InvoiceId { get; set; }
        [Display(Name = "Invoice Number")]
        public string InvoiceName { get; set; }
        [Display(Name = "Sales Order #")]

        [ForeignKey("SalesOrderId")]
        public int SalesOrderId { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTimeOffset InvoiceDate { get; set; }
        [Display(Name = "Invoice Due Date")]
        public DateTimeOffset InvoiceDueDate { get; set; }
        [Display(Name = "Invoice Type")]

        [ForeignKey("InvoiceTypeId")]
        public int InvoiceTypeId { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual InvoiceType InvoiceType { get; set; }
    }
}
