using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Purchasing;
public class Vendor
{
    [Key]
    public string VendorId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    public ICollection<Bill> Bills { get; set; }
}