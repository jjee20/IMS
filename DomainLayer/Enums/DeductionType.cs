using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum DeductionType
    {
        [Display(Name = "Tax Deduction")]
        Tax,

        [Display(Name = "Health Insurance")]
        HealthInsurance,

        [Display(Name = "Retirement Contribution")]
        RetirementContribution,

        [Display(Name = "Social Security")]
        SocialSecurity,

        [Display(Name = "Loan Repayment")]
        LoanRepayment,

        [Display(Name = "Union Fees")]
        UnionFees,

        [Display(Name = "Other Deductions")]
        Other
    }
}
