using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RavenTechV2.Core.Models.AuditTrail;

namespace RavenTechV2.Core.Models.UserManagement;
public class User : IdentityUser
{
    public string FullName { get; set; }
    public virtual ICollection<Role> UserRoles { get; set; }

}