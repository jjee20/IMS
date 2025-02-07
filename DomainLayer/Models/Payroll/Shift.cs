using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Payroll
{
    public class Shift 
    {
        [Key]
        [Display(Name = "Id")]
        public int ShiftId { get; set; } // Primary Key
        [Display(Name = "Shift")]
        public string ShiftName { get; set; } // Example: Morning, Evening
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }
        [Display(Name = "Overtime Rate")]
        public double OvertimeRate { get; set; }
        public double RegularHours { get; set; }
    }

}
