using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.UserManagement;
public class RolePermission
{
    [Key]
    public int RolePermissionId { get; set; }
    public string RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    public int PermissionId { get; set; }
    [ForeignKey("PermissionId")]
    public Permission Permission { get; set; }
}
