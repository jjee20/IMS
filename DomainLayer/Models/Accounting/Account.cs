using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        public AccountType Type { get; set; }

        public decimal Balance { get; set; } = 0;

        public override string ToString()
        {
            return $"{AccountName} ({AccountNumber}) - Balance: {Balance:C}";
        }
    }
}
