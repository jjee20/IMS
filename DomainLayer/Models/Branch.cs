using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Region")]
        public string RegionCode { get; set; }
        [Display(Name = "Province")]
        public string ProvinceCode { get; set; }
        [Display(Name = "City")]
        public string CityCode { get; set; }
        [Display(Name = "Baranggay")]
        public string BarangayCode { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; } 
    }
}
