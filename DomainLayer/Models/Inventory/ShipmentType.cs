using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class ShipmentType 
    {
        [Key]
        [Display(Name = "Id")]
        public int ShipmentTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
    }
}
