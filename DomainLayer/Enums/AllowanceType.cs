using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum AllowanceType
    {
        [Display(Name = "Transport Allowance")]
        Transport,

        [Display(Name = "Housing Allowance")]
        Housing,

        [Display(Name = "Meal Allowance")]
        Meal,

        [Display(Name = "Communication Allowance")]
        Communication,

        [Display(Name = "Medical Allowance")]
        Medical,

        [Display(Name = "Education Allowance")]
        Education,

        [Display(Name = "Utility Allowance")]
        Utility,

        [Display(Name = "Other Allowances")]
        Other
    }
}
