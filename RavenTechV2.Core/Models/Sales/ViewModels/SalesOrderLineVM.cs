using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Models.Inventory;

namespace RavenTechV2.Core.Models.Sales.ViewModels;
public class SalesOrderLineVM
{
    public int SalesOrderLineId { get; set; }
    public string SalesOrder { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
