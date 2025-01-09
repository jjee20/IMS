using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Warehouse
    {
        [Key]
        [Display(Name = "Id")]
        public int WarehouseId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string WarehouseName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Branch")]
        [ForeignKey("BranchId")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
