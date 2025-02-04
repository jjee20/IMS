using DomainLayer.Enums;
using DomainLayer.Models.Payroll;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee : BaseEntity
{
    [Key]
    public int EmployeeId { get; set; } // Primary Key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public double BasicSalary { get; set; }
    public double LeaveCredits { get; set; }
    public string Address { get; set; }
    [ForeignKey(nameof(DepartmentId))]

    public int DepartmentId { get; set; } // Foreign Key
    public Department Department { get; set; }

    [ForeignKey(nameof(JobPositionId))]

    public int JobPositionId { get; set; } // Foreign Key
    public JobPosition JobPosition { get; set; }

    [ForeignKey(nameof(ShiftId))]
    public int ShiftId { get; set; } // Foreign Key
    public Shift Shift { get; set; } // Integration with Shift Management
    public bool isDeducted { get; set; } = true;

    public IEnumerable<Allowance> Allowances { get; set; }
    public IEnumerable<Bonus> Bonuses { get; set; }
    public IEnumerable<Benefit> Benefits { get; set; }
    public IEnumerable<Deduction> Deductions { get; set; }
    public IEnumerable<Attendance> Attendances { get; set; }
    public IEnumerable<Leave> Leaves { get; set; }

}
