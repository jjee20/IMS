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
    public class ProductStockInLogLines
    {
        [Key]
        public int ProductStockInLogLinesId { get; set; }
        public int ProductStockInLogId { get; set; }

        [ForeignKey("ProductStockInLogId")]
        public virtual ProductStockInLogs ProductStockInLogs { get; set; }

        public DateTime DateAdded { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public double StockQuantity { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost => StockQuantity * UnitCost;
    }

}
