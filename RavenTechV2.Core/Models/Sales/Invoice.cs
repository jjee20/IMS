using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales;
public class Invoice
{
    [Key]
    public int InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public int? SalesOrderId { get; set; }
    [ForeignKey("SalesOrderId")]
    public SalesOrder SalesOrder { get; set; }
    public decimal Amount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public InvoiceStatus Status { get; set; }
    public decimal TotalPaid { get; set; }

    [NotMapped]
    public decimal Balance => Amount - TotalPaid;

    [NotMapped]
    public bool IsOverpaid => TotalPaid > Amount;

}
