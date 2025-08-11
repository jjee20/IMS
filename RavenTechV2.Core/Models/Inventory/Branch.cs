using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Inventory;
public class Branch
{
    [Key]
    public int BranchId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactPerson { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [RegularExpression(@"^(\+63|0)9\d{9}$", ErrorMessage = "Invalid Philippine phone number format.")]
    public string Phone { get; set; }
}
