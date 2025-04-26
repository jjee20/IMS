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
        [Display(Name = "Id")]
        public int AllowanceId { get; set; } 
        public string Employee { get; set; } 

        [Required]
        [Display(Name = "Allowance Type")]
        public string AllowanceType { get; set; } 
        public double Amount { get; set; } 

        [Required]
        [Display(Name = "Date Granted")]
        public DateTime DateGranted { get; set; }
        [Display(Name = "Is Recurring?")]

        public string IsRecurring { get; set; } 
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
