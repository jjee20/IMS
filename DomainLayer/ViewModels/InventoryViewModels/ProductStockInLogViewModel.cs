using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Enums;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class ProductStockInLogViewModel
    {
        [Display(Name = "Id")]
        public int ProductStockInLogId { get; set; }
        [Display(Name = "Product/Service")]
        [Required]
        public string Product { get; set; }
        [Display(Name = "Quantity Added")]
        public double StockQuantity { get; set; }
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Status")]
        public string ProductStatus { get; set; }
    }
}
