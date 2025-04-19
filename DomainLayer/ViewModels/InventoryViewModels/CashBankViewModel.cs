using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class CashBankViewModel
    {
        public int CashBankId { get; set; }
        public string CashBankName { get; set; }
        public string Description { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
