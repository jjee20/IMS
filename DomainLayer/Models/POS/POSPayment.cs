using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.POS
{
    public class POSPayment
    {
        public class Payment
        {
            [Key] 
            public int PaymentId { get; set; }
            [ForeignKey(nameof(OrderId))]
            public int OrderId { get; set; }
            public virtual Order Order { get; set; }
            public decimal AmountPaid { get; set; }
            public PaymentMethod PaymentMethod { get; set; }
            public DateTime PaymentDate { get; set; } = DateTime.Now;
        }

    }
}
