using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.MasterData;

namespace RavenTechV2.Core.Models.Payroll;
public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Address { get; set; }
    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
    public int JobPositionId { get; set; }
    [ForeignKey("JobPositionId")]
    public JobPosition JobPosition { get; set; }
    public decimal BasicPay { get; set; }
    public decimal LeaveCredits { get; set; }
    public int ShiftId { get; set; }
    [ForeignKey("ShiftId")]
    public Shift Shift { get; set; }
    public bool IsDeducted { get; set; }
}
