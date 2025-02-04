using DomainLayer.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        [ForeignKey("ProductTypeId")]
        public int ProductTypeId { get; set; }
        public string? ProductImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        [Display(Name = "UOM")]
        [ForeignKey("UnitOfMeasureId")]
        public int UnitOfMeasureId { get; set; }
        public double DefaultBuyingPrice { get; set; } = 0.0;
        public double DefaultSellingPrice { get; set; } = 0.0;
        [Display(Name = "Branch")]
        [ForeignKey("BranchId")]
        public int BranchId { get; set; }

        [NotMapped]
        public string DisplayInfo => $"{ProductName} - {DefaultSellingPrice:C}";
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
