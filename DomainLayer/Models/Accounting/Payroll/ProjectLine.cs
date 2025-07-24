using DomainLayer.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class ProjectLine
    {
        [Key]
        public int ProjectLineId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount => Quantity * Price;
        [Display(Name = "Disc %")]
        public double DiscountPercentage { get; set; }
        public double DiscountAmount => Amount * (DiscountPercentage / 100);
        public double SubTotal => Amount - DiscountAmount;

        public string? DeliveredBy { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string? ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
    }
}
