using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Payroll;
public class Contribution
{
    [Key]
    public int ContributionId { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
    public string ContributionType { get; set; }
    public decimal Amount { get; set; }
    public DateTime ContributionDate { get; set; }
}
