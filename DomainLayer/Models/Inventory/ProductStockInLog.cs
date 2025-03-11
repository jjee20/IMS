using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class ProductStockInLog
    {
        [Key]
        public int ProductStockInLogId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public double StockQuantity { get; set; }
        public DateTime DateAdded { get; set; }
        public string Notes { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
