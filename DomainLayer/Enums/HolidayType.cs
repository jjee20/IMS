using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum HolidayType
    {
        [Display(Name = "Regular Holiday")]
        RegularHoliday,
        [Display(Name = "Special Non-Working Holiday")]
        SpecialNonWorkingHoliday,
        [Display(Name = "Special Working Holiday")]
        SpecialWorkingHoliday
    }
}
