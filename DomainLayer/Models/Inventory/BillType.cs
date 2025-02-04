using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class BillType : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        public int BillTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string BillTypeName { get; set; }
        public string Description { get; set; }
    }
}
