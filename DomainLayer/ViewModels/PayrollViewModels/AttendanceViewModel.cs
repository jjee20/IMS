using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class AttendanceViewModel
    {
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        [Display(Name = "Total Days")]
        public int TotalDays { get; set; }
        [Display(Name = "Days Present")]
        public double DaysPresent { get; set; }
        [Display(Name = "Total Overtime (hrs)")]
        public double TotalOvertime { get; set; }
        [Display(Name = "Days Late")]
        public int DaysLate { get; set; }
        [Display(Name = "Days Early-out")]
        public int DaysEarlyOut { get; set; }
        [Display(Name = "Days Absent")]
        public double DaysAbsent { get; set; }
        [Display(Name = "Days OnLeave")]
        public int DaysOnLeave { get; set; }
    }
}
