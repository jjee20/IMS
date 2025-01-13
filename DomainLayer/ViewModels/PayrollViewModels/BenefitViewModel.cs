using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class BenefitViewModel
    {
        [Display(Name ="Id")]
        public int BenefitId { get; set; } // Primary Key
        public string Employee { get; set; }
        [Display(Name = "Benefit Type")]
        public string BenefitType { get; set; } // Example: "Health Insurance", "Transportation"
        public double Amount { get; set; }
        public string Other { get; set; }
    }
}
