using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.Payroll;

namespace RavenTechV2.Core.Models.Projects;
public class ProjectResource
{
    [Key]
    public int ProjectResourceId { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
    public string Role { get; set; }
    public double AllocationPercent { get; set; }
}
