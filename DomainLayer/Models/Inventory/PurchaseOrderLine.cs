using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class PurchaseOrderLine
    {
        [Key]
        public int PurchaseOrderLineId { get; set; }
        [Display(Name = "Purchase Order")]
        [ForeignKey("PurchaseOrderId")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Purchase Order")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
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
