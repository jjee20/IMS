using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Purchasing;
public class Vendor
{
    [Key]
    public int VendorId { get; set; }
    [Required]
    public string Name { get; set; }
    public VendorType Type { get; set; }
    public string Address { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [RegularExpression(@"^(\+63|0)9\d{9}$", ErrorMessage = "Invalid Philippine phone number format.")]
    public string Phone { get; set; }
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    public ICollection<Bill> Bills { get; set; }
}