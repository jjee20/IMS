using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public HolidayType HolidayType { get; set; } // 🔁 Replaces IsPublicHoliday and IsPaidHoliday
        public string? Description { get; set; }
    }
}
