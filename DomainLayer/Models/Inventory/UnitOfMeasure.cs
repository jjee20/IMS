using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class UnitOfMeasure
    {
        [Key]
        [Display(Name = "Id")]
        public int UnitOfMeasureId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string UnitOfMeasureName { get; set; }
        public string Description { get; set; }
    }
}
