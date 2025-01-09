using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class PaymentVoucher
    {
        [Key]
        public int PaymentVoucherId { get; set; }
        [Display(Name = "Payment Voucher Number")]
        public string PaymentVoucherName { get; set; }
        [Display(Name = "Bill")]
        [ForeignKey("BillId")]
        public int BillId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        [ForeignKey("PaymentTypeId")]
        public int PaymentTypeId { get; set; }
        public double PaymentAmount { get; set; }
        [Display(Name = "Payment Source")]
        [ForeignKey("CashBankId")]
        public int CashBankId { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; } = true;
        public virtual Bill Bill { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual CashBank CashBank { get; set; }
    }
}
