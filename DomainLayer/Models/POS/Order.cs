using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.POS
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } // Nullable if guest
        [ForeignKey(nameof(TableId))]
        public int TableId { get; set; }
        public Table? Table { get; set; } // Link to ongoing order
        public List<OrderItem> Items { get; set; } = new();
        public decimal Subtotal => Items.Sum(i => i.TotalPrice);
        public decimal Tax => Subtotal * 0.12m; // Example 22.5% tax
        public decimal Total => Subtotal + Tax;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
