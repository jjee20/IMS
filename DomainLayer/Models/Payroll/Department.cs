using DomainLayer.Models.Payroll;
using System.ComponentModel.DataAnnotations;

public class Department : BaseEntity
{
    [Key]
    [Display(Name= "Id")]
    public int DepartmentId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Description { get; set; }
}
