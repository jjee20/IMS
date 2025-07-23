using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.UserManagement;

namespace RavenTechV2.Core.Models.AuditTrail;
public class Notification
{
    [Key]
    public int NotificationId { get; set; }
    public string UserId { get; set; } // Null for system-wide
    [ForeignKey("UserId")]
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; }
    public string Url { get; set; } // Where to go on click
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
}

