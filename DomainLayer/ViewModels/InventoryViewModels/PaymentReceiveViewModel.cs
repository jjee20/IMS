using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class PaymentReceiveViewModel
    {
        [Display(Name = "Id")]
        public int PaymentReceiveId { get; set; }
        [Display(Name = "Payment Receive #")]
        public string PaymentReceiveName { get; set; }
        [Display(Name = "Sales Order #")]
        public string SalesOrder { get; set; }
        [Display(Name = "Payment Date")]
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Amount")]
        public double PaymentAmount { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; } = true;
        public byte[] Delete { get; set; }
    }
}
