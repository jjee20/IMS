using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class InvoiceType
    {
        [Key]
        [Display(Name = "Id")]
        public int InvoiceTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
    }
}
