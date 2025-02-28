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
        public int ContributionId { get; set; }
        public ContributionType ContributionType { get; set; }
        public double EmployeeRate { get; set; }
        public double EmployerRate { get; set; }
        public double MinimumLimit { get; set; }
        public double MaximumLimit { get; set; }
        public double? MandatoryProvidentFund { get; set; }
    }
}
