using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class AllowanceViewModel
    {
        [Display(Name = "#")]
        public int AllowanceId { get; set; } 
        public string Employee { get; set; } 

        [Required]
        [Display(Name = "Allowanc eType")]
        public string AllowanceType { get; set; } 
        public double Amount { get; set; } 

        public string Description { get; set; }

        [Required]
        [Display(Name = "Date Granted")]
        public DateTime DateGranted { get; set; }
        [Display(Name = "Is Recurring?")]

        public string IsRecurring { get; set; } 
    }
}
