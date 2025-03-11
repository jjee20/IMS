using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class PaymentReceiveInfoViewModel
    {
        [Display(Name = "Payment Receive #")]
        public string PaymentReceiveName { get; set; }
        [Display(Name = "Payment Date")]
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Amount")]
        public double PaymentAmount { get; set; }
    }
}
