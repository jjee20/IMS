using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Enums;
public enum PaymentType
{
    [Display(Name = "Cash")]
    Cash,

    [Display(Name = "Credit Card")]
    CreditCard,

    [Display(Name = "Debit Card")]
    DebitCard,

    [Display(Name = "Bank Transfer")]
    BankTransfer,

    [Display(Name = "GCash")]
    GCash,

    [Display(Name = "PayMaya")]
    PayMaya,

    [Display(Name = "Check")]
    Check,

    [Display(Name = "Online Payment")]
    OnlinePayment,

    [Display(Name = "Cash on Delivery")]
    COD,
    Other
}

