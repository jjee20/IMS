using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Inventory.ViewModels;
public class ProductVM
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public string Description { get; set; }
    public string ProductType { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal DefaultBuyPrice { get; set; }
    public decimal DefaultSellPrice { get; set; }
    public int ReorderLevel { get; set; }
    public string Branch { get; set; }
    public string IsActive { get; set; } 
}
