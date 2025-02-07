using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum BonusType
    {
        [Display(Name = "Performance Bonus")]
        Performance,

        [Display(Name = "Holiday Bonus")]
        Holiday,

        [Display(Name = "Year-End Bonus")]
        YearEnd,

        [Display(Name = "Referral Bonus")]
        Referral,

        [Display(Name = "Retention Bonus")]
        Retention,

        [Display(Name = "Signing Bonus")]
        Signing,

        [Display(Name = "Special Achievement Bonus")]
        SpecialAchievement,

        [Display(Name = "Other Bonuses")]
        Other
    }
}
