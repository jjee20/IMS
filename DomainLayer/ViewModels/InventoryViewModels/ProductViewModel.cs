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
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Display(Name = "Code")]
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string Description { get; set; }
        [Display(Name = "UOM")]
        public string UnitOfMeasure { get; set; }
        public double DefaultBuyingPrice { get; set; } = 0.0;
        public double IncrementPrice { get; set; } = 0.0;
        public double DefaultSellingPrice { get; set; } = 0.0;
        public string Branch { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
