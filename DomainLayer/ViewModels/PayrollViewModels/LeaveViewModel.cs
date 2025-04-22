using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class LeaveViewModel
    {
        [Display(Name ="Id")]
        public int LeaveId { get; set; } 
        public string Employee { get; set; }
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; } // Example: "Vacation", "Sick Leave"
        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Example: "Approved", "Pending", "Rejected"
        public string Notes { get; set; }
        public string Other { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
