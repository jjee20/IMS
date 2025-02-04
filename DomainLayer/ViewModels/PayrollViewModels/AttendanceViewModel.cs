using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Enums;
using DomainLayer.Models.Payroll;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class AttendanceViewModel
    {
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        [Display(Name = "Total Days")]
        public int TotalDays { get; set; }
        [Display(Name = "Days Present")]
        public int DaysPresent { get; set; }
        [Display(Name = "Days Late")]
        public int DaysLate { get; set; }
        [Display(Name = "Days Early-out")]
        public int DaysEarlyOut { get; set; }
        [Display(Name = "Days Absent")]
        public int DaysAbsent { get; set; }
        [Display(Name = "Days OnLeave")]
        public int DaysOnLeave { get; set; }
    }
}
