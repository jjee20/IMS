using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales.ViewModels;
public class InvoiceVM
{
    public int InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public string Customer { get; set; }
    public string SalesOrder { get; set; }
    public decimal Amount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal Balance => Amount - TotalPaid;
    public bool IsOverpaid => TotalPaid > Amount;

}
