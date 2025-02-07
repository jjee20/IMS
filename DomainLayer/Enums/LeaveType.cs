using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum LeaveType
    {
        [Display(Name = "Casual")]
        CasualLeave,
        [Display(Name = "Sick")]
        SickLeave,
        [Display(Name = "Maternity")]
        MaternityLeave,
        [Display(Name = "Paternity")]
        PaternityLeave,
        [Display(Name = "Annual")]
        AnnualLeave,
        [Display(Name = "Unpaid")]
        UnpaidLeave,
        [Display(Name = "Compensatory")]
        CompensatoryLeave,
        Other
    }
}
