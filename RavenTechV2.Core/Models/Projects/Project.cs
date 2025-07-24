using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.MasterData;
using RavenTechV2.Core.Models.Payroll;

namespace RavenTechV2.Core.Models.Projects;
public class Project
{
    [Key]
    public int ProjectId { get; set; }
    [Required]
    public string ProjectName { get; set; }
    public string ProjectCode { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; }
    public int? BranchId { get; set; }
    [ForeignKey("BranchId")]
    public Branch Branch { get; set; }
    public int? ManagerId { get; set; }
    [ForeignKey("ManagerId")]
    public Employee Manager { get; set; }
}
