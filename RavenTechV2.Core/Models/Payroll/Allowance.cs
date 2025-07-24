using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Payroll;
public class Allowance
{
    [Key]
    public int AllowanceId { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
    public string AllowanceType { get; set; }
    public DateTime DateGranted { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
