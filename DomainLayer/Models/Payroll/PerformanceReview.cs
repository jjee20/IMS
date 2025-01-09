using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class PerformanceReview
    {
        public int PerformanceReviewId { get; set; } // Primary Key
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }

        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; } // Name of the reviewer
        public string Feedback { get; set; }
        public int Rating { get; set; } // Example: 1 to 5 stars
    }

}
