using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Display(Name = "Vendor Type")]
        public int VendorTypeId { get; set; }
        [Display(Name = "Street Address")]
        public string Region { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string Barangay { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [ForeignKey("VendorTypeId")]
        public virtual VendorType VendorType { get; set; }
    }
}
