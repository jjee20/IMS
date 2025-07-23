using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.UserManagement;
public class Permission
{
    [Key]
    public int PermissionId { get; set; }
    [Required]
    public string PermissionName { get; set; } // e.g., "EditInvoice", "ApprovePO"
    public string Description { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}