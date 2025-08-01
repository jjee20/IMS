using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.MasterData;

namespace RavenTechV2.Core.Models.Inventory;
public class WarehouseVM
{
    public int WarehouseId { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }
    public string Description { get; set; }
}
