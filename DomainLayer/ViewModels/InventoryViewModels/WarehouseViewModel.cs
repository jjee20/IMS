using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class WarehouseViewModel
    {
        [Display(Name = "Id")]
        public int WarehouseId { get; set; }
        [Display(Name = "Name")]
        public string WarehouseName { get; set; }
        public string Description { get; set; }
        public string Branch { get; set; }
    }
}
