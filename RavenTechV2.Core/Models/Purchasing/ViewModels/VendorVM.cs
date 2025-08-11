using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Purchasing.ViewModels;
public class VendorVM
{
    public int VendorId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ICollection<PurchaseOrderVM> PurchaseOrders { get; set; }
    public ICollection<BillVM> Bills { get; set; }
}