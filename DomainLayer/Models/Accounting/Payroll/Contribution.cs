using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class Contribution
    {
        [Key]
        [Display(Name = "Id")]
        public int ContributionId { get; set; }
        [Display(Name = "Contribution Type")]
        public ContributionType ContributionType { get; set; }
        [Display(Name = "Employee Rate")]
        public double EmployeeRate { get; set; }
        [Display(Name = "Employer Rate")]
        public double EmployerRate { get; set; }
        [Display(Name = "Minimum Limit")]
        public double MinimumLimit { get; set; }
        [Display(Name = "Maximum Limit")]
        public double MaximumLimit { get; set; }
        [Display(Name = "MPF")]
        public double? MandatoryProvidentFund { get; set; }
    }
}
