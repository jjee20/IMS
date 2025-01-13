using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class SalesOrderViewModel
    {
        [Display(Name = "Id")]
        public int SalesOrderId { get; set; }
        [Display(Name = "Order #")]
        public string SalesOrderName { get; set; }
        public string Branch { get; set; }
        public string Customer { get; set; }
        [Display(Name = "Order Date")]
        public DateTimeOffset OrderDate { get; set; }
        [Display(Name = "Delivery Date")]
        public DateTimeOffset DeliveryDate { get; set; }

        [Display(Name = "Customer Ref. #")]
        public string CustomerRefNumber { get; set; }
        [Display(Name = "Sales Type")]
        public string SalesType { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
    }
}
