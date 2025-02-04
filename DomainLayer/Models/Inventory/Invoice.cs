using DomainLayer.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Invoice : BaseEntity
    {
        [Key]
        public int InvoiceId { get; set; }
        [Display(Name = "Invoice Number")]
        public string InvoiceName { get; set; }
        [Display(Name = "Shipment")]

        [ForeignKey("ShipmentId")]
        public int ShipmentId { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTimeOffset InvoiceDate { get; set; }
        [Display(Name = "Invoice Due Date")]
        public DateTimeOffset InvoiceDueDate { get; set; }
        [Display(Name = "Invoice Type")]

        [ForeignKey("InvoiceTypeId")]
        public int InvoiceTypeId { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual InvoiceType InvoiceType { get; set; }
    }
}
