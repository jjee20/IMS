using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class ProductType 
    {
        [Key]
        [Display(Name = "Id")]
        public int ProductTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
    }
}
