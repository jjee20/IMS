using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Product 
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
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
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
        public string DisplayInfo
        {
            get
            {
                var brand = string.IsNullOrWhiteSpace(Brand) ? "" : $" ({Brand})";
                var color = string.IsNullOrWhiteSpace(Color) ? "" : $" - {Color}";
                var size = string.IsNullOrWhiteSpace(Size) ? "" : $", Size {Size}";

                return $"{ProductName}{brand}{color}{size}";
            }
        }


        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ProductType ProductType { get; set; }

        public IEnumerable<ProductStockInLogs> ProductStockInLogs { get; set; }
        public IEnumerable<ProductPullOutLogs> ProductPullOutLogs { get; set; }
    }
}
