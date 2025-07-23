using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.MasterData;

namespace RavenTechV2.Core.Models.Inventory;
public class Warehouse
{
    [Key]
    public int WarehouseId { get; set; }
    [Required]
    public string Name { get; set; }
    public int BranchId { get; set; }
    [ForeignKey("BranchId")]
    public Branch Branch { get; set; }
    public string Description { get; set; }
}
