using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.POS
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public POSProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; } // In percentage
        public decimal TotalPrice => (Product.Price * Quantity) * (1 - (Discount / 100));
    }
}
