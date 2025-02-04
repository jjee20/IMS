using DomainLayer.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Vendor : BaseEntity
    {
        [Key]
        public int VendorId { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Display(Name = "Vendor Type")]
        [ForeignKey("VendorTypeId")]
        public int VendorTypeId { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        public virtual VendorType VendorType { get; set; }
    }
}
