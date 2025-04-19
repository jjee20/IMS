using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class MonthlyBreakdown
    {
        public string Month { get; set; }
        public int DaysWorked { get; set; }
        public double Amount { get; set; }
    }
}
