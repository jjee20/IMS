using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser
    {
        [Key]
        public Guid ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
