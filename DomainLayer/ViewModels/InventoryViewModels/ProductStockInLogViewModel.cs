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
    public class ProductStockInLogViewModel
    {
        public int ProductStockInLogId { get; set; }
        public string Product { get; set; }
        public double StockQuantity { get; set; }
        public DateTime DateAdded { get; set; }
        public string Notes { get; set; }
        public string ProductStatus { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
