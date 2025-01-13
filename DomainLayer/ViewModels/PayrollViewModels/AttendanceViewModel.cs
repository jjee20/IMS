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
        [Key]
        [Display(Name = "Id")]
        public int AttendanceId { get; set; }
        public string Employee { get; set; }

        public DateTime Date { get; set; }
        [Display(Name = "Time-in")]
        public TimeSpan TimeIn { get; set; }
        [Display(Name = "Time-out")]
        public TimeSpan TimeOut { get; set; }
        [Display(Name = "Hours Worked")]
        public double HoursWorked { get; set; }
        public string Status { get; set; }
    }
}
