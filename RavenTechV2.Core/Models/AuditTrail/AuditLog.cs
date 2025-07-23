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
public class AuditLog
{
    [Key]
    public int AuditLogId { get; set; }
    [Required]
    public DateTime Timestamp { get; set; }
    [Required]
    public string UserId { get; set; } // Foreign key to User
    [ForeignKey("UserId")]
    public User User { get; set; }
    [Required]
    public string EntityName { get; set; }   // e.g., "Invoice", "Product"
    public int? EntityId { get; set; }       // Record key value
    [Required]
    public AuditAction Action { get; set; }  // Created, Updated, Deleted
    public string FieldName { get; set; }    // If you want per-field detail
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public string Remarks { get; set; }
}
