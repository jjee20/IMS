using DomainLayer.Models.Accounts;
using System.ComponentModel.DataAnnotations;

public class DepartmentViewModel
{
    [Display(Name= "Id")]
    public int DepartmentId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Edit { get; set; }
    public byte[] Delete { get; set; }
}
