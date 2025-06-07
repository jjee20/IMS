using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class ProductPullOutLogs
    {
        [Key]
        public int ProductPullOutLogId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string Notes { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public string? DeliveredBy { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string? ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public List<ProductPullOutLogLines> ProductPullOutLogLines { get; set; }
    }
}
