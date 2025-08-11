using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales.ViewModels;
public class SalesOrderVM
{
    public int SalesOrderId { get; set; }
    public string SalesOrderNumber { get; set; }
    public string Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public string Status { get; set; }
    public string SalesType { get; set; }  
    public string ShipmentType { get; set; }
    public ICollection<SalesOrderLineVM> SalesOrderLines { get; set; }
}
