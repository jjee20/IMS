using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class ShiftViewModel
    {
        [Display(Name = "Id")]
        public int ShiftId { get; set; } // Primary Key
        [Display(Name = "Shift")]
        public string ShiftName { get; set; } // Example: Morning, Evening
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }
        [Display(Name = "Regular Hours")]
        public double RegularHours { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
