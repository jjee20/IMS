using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models.Inventory;

namespace DomainLayer.ViewModels.Inventory
{
    public class PurchaseOrderViewModel
    {
        [Display(Name = "Id")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Order #")]
        public string PurchaseOrderName { get; set; }
        public string Branch { get; set; }
        public string Vendor { get; set; }
        [Display(Name = "Order Date")]
        public DateTimeOffset OrderDate { get; set; }
        [Display(Name = "Delivery Date")]
        public DateTimeOffset DeliveryDate { get; set; }
        [Display(Name = "Purchase Type")]
        public string PurchaseType { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
        public byte[] GRN { get; set; }
        public byte[] Bill { get; set; }
        public byte[] Voucher { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
