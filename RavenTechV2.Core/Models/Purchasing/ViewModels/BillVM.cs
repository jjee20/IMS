using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Purchasing.ViewModels;
public class BillVM
{
    public int BillId { get; set; }
    public string BillNumber { get; set; }
    public string Vendor { get; set; }
    public string PurchaseOrder { get; set; }
    public decimal Amount { get; set; }
    public DateTime BillDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public decimal TotalPaid { get; set; }

    [NotMapped]
    public decimal Balance => Amount - TotalPaid;

    [NotMapped]
    public bool IsOverpaid => TotalPaid > Amount;
}
