using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; } // Primary Key
        public DateTime Timestamp { get; set; }
        public string User { get; set; } // The username who performed the action
        public string Action { get; set; } // Example: "Created Employee", "Updated Payroll"
        public string Details { get; set; } // Additional information about the action
    }

}
