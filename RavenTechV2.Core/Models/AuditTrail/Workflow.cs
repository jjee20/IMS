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
public class WorkflowState
{
    [Key]
    public int WorkflowStateId { get; set; }
    [Required]
    public string EntityName { get; set; } // e.g., "PurchaseOrder", "Invoice"
    public int EntityId { get; set; }
    [Required]
    public WorkflowStage CurrentStage { get; set; }
    public DateTime StatusChangedAt { get; set; }
    public string ChangedByUserId { get; set; }
    [ForeignKey("ChangedByUserId")]
    public User ChangedBy { get; set; }
    public string Remarks { get; set; }
}