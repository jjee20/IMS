using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class ShipmentViewModel
    {
        [Display(Name = "Id")]
        public int ShipmentId { get; set; }
        [Display(Name = "Shipment #")]
        public string ShipmentName { get; set; }
        [Display(Name = "Sales Order #")]
        public string SalesOrder { get; set; }
        [Display(Name = "Shipment Date")]
        public DateTimeOffset ShipmentDate { get; set; }
        [Display(Name = "Shipment Type")]
        public string ShipmentType { get; set; }
        public string Warehouse { get; set; }
        [Display(Name = "Full Shipment")]
        public bool IsFullShipment { get; set; } = true;
    }
}
