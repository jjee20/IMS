using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class SalesOrderLine
    {
        [Key]
        public int SalesOrderLineId { get; set; }
        [Display(Name = "Sales Order")]
        [ForeignKey("SalesOrderId")]
        public int SalesOrderId { get; set; }
        [Display(Name = "Sales Order")]
        public virtual SalesOrder SalesOrder { get; set; }
        [Display(Name = "Product Item")]
        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        [Display(Name = "Disc %")]
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double SubTotal { get; set; }
        public virtual Product Product { get; set; }

    }
}
