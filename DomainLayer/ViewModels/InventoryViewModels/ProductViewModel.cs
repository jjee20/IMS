using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class ProductViewModel
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }
        [Display(Name = "Product/Service")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Code")]
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string? ProductImageUrl { get; set; }
        [Display(Name = "UOM")]
        public string UnitOfMeasure { get; set; }
        [Display(Name = "Buying Price")]
        public double DefaultBuyingPrice { get; set; } = 0.0;
        [Display(Name = "Selling Price")]
        public double DefaultSellingPrice { get; set; } = 0.0;
        public string Branch { get; set; }
    }
}
