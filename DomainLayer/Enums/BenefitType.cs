using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum BenefitType
    {
        [Display(Name = "Health Insurance")]
        HealthInsurance,

        [Display(Name = "Dental Insurance")]
        DentalInsurance,

        [Display(Name = "Vision Insurance")]
        VisionInsurance,

        [Display(Name = "Retirement Savings (401k)")]
        RetirementSavings,

        [Display(Name = "Paid Time Off (PTO)")]
        PaidTimeOff,

        [Display(Name = "Life Insurance")]
        LifeInsurance,

        [Display(Name = "Disability Insurance")]
        DisabilityInsurance,

        [Display(Name = "Education Assistance")]
        EducationAssistance,

        [Display(Name = "Transportation Benefits")]
        TransportationBenefits,

        [Display(Name = "Wellness Program")]
        WellnessProgram,

        [Display(Name = "Stock Options")]
        StockOptions,

        [Display(Name = "Flexible Spending Account (FSA)")]
        FlexibleSpendingAccount,

        [Display(Name = "Employee Assistance Program (EAP)")]
        EmployeeAssistanceProgram,

        [Display(Name = "Childcare Assistance")]
        ChildcareAssistance,

        [Display(Name = "Other Benefits")]
        Other
    }
}
