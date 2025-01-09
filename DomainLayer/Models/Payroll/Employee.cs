using DomainLayer.Enums;
using DomainLayer.Models.Payroll;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; } // Primary Key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    [ForeignKey(nameof(DepartmentId))]

    public int DepartmentId { get; set; } // Foreign Key
    public Department Department { get; set; }
    [ForeignKey(nameof(JobPositionId))]

    public int JobPositionId { get; set; } // Foreign Key
    public JobPosition JobPosition { get; set; }

    public ICollection<Payroll> Payrolls { get; set; } // Navigation Property
    public bool isDeducted { get; set; } = true;
}
