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
    public class ProductPullOutLogLines
    {
        [Key]
        public int ProductPullOutLogLinesId { get; set; }
        public int ProductPullOutId { get; set; }

        [ForeignKey("ProductPullOutLogId")]
        public virtual ProductPullOutLogs ProductPullOutLogs { get; set; }

        public DateTime DateAdded { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public double StockQuantity { get; set; }
    }

}
