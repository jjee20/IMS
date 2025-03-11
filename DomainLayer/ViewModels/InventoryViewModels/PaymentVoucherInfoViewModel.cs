using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class PaymentVoucherInfoViewModel
    {
        [Display(Name = "Payment Voucher #")]
        public string PaymentVoucherName { get; set; }
        [Display(Name = "Purchase Order #")]
        public string PurchaseOrder { get; set; }
        [Display(Name = "Payment Date")]
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Amount")]
        public double PaymentAmount { get; set; }
        [Display(Name = "Payment Source")]
        public string CashBank { get; set; }
    }
}
