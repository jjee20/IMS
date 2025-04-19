using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class VendorViewModel
    {
        [Display(Name = "Id")]
        public int VendorId { get; set; }
        [Display(Name = "Name")]
        public string VendorName { get; set; }
        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
