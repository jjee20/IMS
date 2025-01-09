using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key] 
    public int DepartmentId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Employee> Employees { get; set; } // Navigation Property
}
