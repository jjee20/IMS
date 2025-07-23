using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales;
public class SalesOrder
{
    [Key]
    public int SalesOrderId { get; set; }
    [Required]
    public string SalesOrderNumber { get; set; }
    [Required]
    public string CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public SalesOrderStatus Status { get; set; }
    public ICollection<SalesOrderLine> SalesOrderLines { get; set; }
}
