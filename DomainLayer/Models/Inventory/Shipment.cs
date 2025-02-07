using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class Shipment 
    {
        [Key]
        public int ShipmentId { get; set; }
        [Display(Name = "Shipment Number")]
        public string ShipmentName { get; set; }
        [Display(Name = "Sales Order")]
        [ForeignKey("SalesOrderId")]
        public int SalesOrderId { get; set; }
        public DateTimeOffset ShipmentDate { get; set; }
        [Display(Name = "Shipment Type")]
        [ForeignKey("ShipmentTypeId")]
        public int ShipmentTypeId { get; set; }
        [Display(Name = "Warehouse")]
        [ForeignKey("WarehouseId")]
        public int WarehouseId { get; set; }
        [Display(Name = "Full Shipment")]
        public bool IsFullShipment { get; set; } = true;
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual ShipmentType ShipmentType { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
