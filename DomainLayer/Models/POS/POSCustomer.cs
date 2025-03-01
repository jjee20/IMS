using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.POS
{
    public class POSCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; } = "Guest";
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
