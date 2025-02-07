using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class CustomerType 
    {
        [Key]
        [Display(Name = "Id")]
        public int CustomerTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }
    }
}
