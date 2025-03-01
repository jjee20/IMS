using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Accounts
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public UserProfile Profile { get; set; }
        public Departments Department { get; set; }
        public IEnumerable<TaskRoles>? TaskRoles { get; set; }
    }
}

