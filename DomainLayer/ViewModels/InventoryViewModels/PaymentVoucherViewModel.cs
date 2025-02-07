using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class PaymentVoucherViewModel
    {
        [Display(Name = "Id")]
        public int PaymentVoucherId { get; set; }
        [Display(Name = "Payment Voucher #")]
        public string PaymentVoucherName { get; set; }
        [Display(Name = "Bill #")]
        public string Bill { get; set; }
        [Display(Name = "Payment Date")]
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Amount")]
        public double PaymentAmount { get; set; }
        [Display(Name = "Payment Source")]
        public string CashBank { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; } = true;
    }
}
