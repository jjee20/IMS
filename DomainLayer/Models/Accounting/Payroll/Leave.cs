using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; } // Primary Key
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; } // Example: "Vacation", "Sick Leave"
        public Status Status { get; set; } // Example: "Approved", "Pending", "Rejected"
        public string Notes { get; set; }
        public string Other { get; set; }
    }

}
