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
    public class IndividualAttendanceViewModel
    {
        [Display(Name = "#")]
        public int AttendanceId { get; set; }
        public string Project { get; set; }
        public string Date { get; set; }
        [Display(Name = "Time-in")]
        public TimeSpan TimeIn { get; set; }
        [Display(Name = "Time-out")]
        public TimeSpan TimeOut { get; set; }
        [Display(Name = "Hours Worked")]
        public double HoursWorked { get; set; }
        public string Status { get; set; }
    }
}
