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
    public class EmployeeContribution
    {
        [Key]
        [Display(Name = "Id")]
        public int EmployeeContributionId { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public double SSS { get; set; }
        public double SSSWISP { get; set; }
        public double PagIbig { get; set; }
        public double PhilHealth { get; set; }
    }
}
