using DomainLayer.Models.Accounts;
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
        [Display(Name = "PurchaseOrder")]
        [ForeignKey("PurchaseOrderId")]
        public int PurchaseOrderId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        [ForeignKey("PaymentTypeId")]
        public int PaymentTypeId { get; set; }
        public double PaymentAmount { get; set; }
        [Display(Name = "Payment Source")]
        [ForeignKey("CashBankId")]
        public int CashBankId { get; set; }
        [Display(Name = "Full Payment")]
        public string Remarks { get; set; }
        public bool IsFullPayment { get; set; } = true;
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual CashBank CashBank { get; set; }
    }
}
