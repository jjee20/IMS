using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.MasterData;

namespace RavenTechV2.Core.Models.Inventory;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public string Description { get; set; }
    public string ProductType { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public int UnitOfMeasureId { get; set; }
    [ForeignKey("UnitOfMeasureId")]
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public decimal DefaultBuyPrice { get; set; }
    public decimal DefaultSellPrice { get; set; }
    public int ReorderLevel { get; set; }
    public int BranchId { get; set; }
    [ForeignKey("BranchId")]
    public Branch Branch { get; set; }
    public bool IsActive { get; set; }
}
