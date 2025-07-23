using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.UserManagement;

namespace RavenTechV2.Core.Models.AuditTrail;
public class WorkflowTransition
{
    [Key]
    public int WorkflowTransitionId { get; set; }
    [Required]
    public string EntityName { get; set; }
    public int EntityId { get; set; }
    [Required]
    public WorkflowStage FromStage { get; set; }
    [Required]
    public WorkflowStage ToStage { get; set; }
    public DateTime TransitionDate { get; set; }
    public string PerformedByUserId { get; set; }
    [ForeignKey("PerformedByUserId")]
    public User PerformedBy { get; set; }
    public string Remarks { get; set; }
}

