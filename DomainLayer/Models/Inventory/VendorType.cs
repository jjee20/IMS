using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class VendorType
    {
        [Key]
        [Display(Name = "Id")]
        public int VendorTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string VendorTypeName { get; set; }
        public string Description { get; set; }
    }
}
