using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Payroll
{
    public class Attendance 
    {
        [Key]
        public int AttendanceId { get; set; } // Primary Key
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }

        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public double HoursWorked { get; set; }
             
        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; } // Foreign Key
        public Project Project { get; set; }
    }

}
