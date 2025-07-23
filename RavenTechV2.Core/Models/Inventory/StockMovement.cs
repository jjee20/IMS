using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Inventory;
public class StockMovement
{
    [Key]
    public int StockMovementId { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    public int WarehouseId { get; set; }
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }
    public int Quantity { get; set; }
    public StockMovementType MovementType { get; set; }
    public DateTime MovementDate { get; set; }
    public string Reference { get; set; }
    public string Remarks { get; set; }
}