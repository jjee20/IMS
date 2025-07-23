using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Payroll;
public class Attendance
{
    [Key]
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
    public DateTime Date { get; set; }
    public DateTime? TimeIn { get; set; }
    public DateTime? TimeOut { get; set; }
    public double HoursWorked { get; set; }
    public bool IsPresent { get; set; }
    public bool IsHalfDay { get; set; }
}
