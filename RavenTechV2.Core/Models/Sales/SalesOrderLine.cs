using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.Inventory;

namespace RavenTechV2.Core.Models.Sales;
public class SalesOrderLine
{
    [Key]
    public int SalesOrderLineId { get; set; }
    [Required]
    public int SalesOrderId { get; set; }
    [ForeignKey("SalesOrderId")]
    public SalesOrder SalesOrder { get; set; }
    [Required]
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
