using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class SalesOrder 
    {
        [Key]
        public int SalesOrderId { get; set; }
        [Display(Name = "Order Number")]
        public string SalesOrderName { get; set; }
        [Display(Name = "Branch")]

        [ForeignKey("BranchId")]
        public int BranchId { get; set; }
        [Display(Name = "Customer")]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }

        [Display(Name = "Customer Ref. Number")]
        public string CustomerRefNumber { get; set; }
        [Display(Name = "Sales Type")]
        [ForeignKey("SalesTypeId")]
        public int SalesTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
        public List<SalesOrderLine> SalesOrderLines { get; set; } = new List<SalesOrderLine>();
        public virtual Branch Branch { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SalesType SalesType { get; set; }

        public Shipment Shipment { get; set; }
        public Invoice Invoice { get; set; }
        public IEnumerable<PaymentReceive> PaymentReceive { get; set; }

        [NotMapped]
        public string InvoiceDisplay => $"{SalesOrderName}-{Customer.CustomerName}";
    }
}
