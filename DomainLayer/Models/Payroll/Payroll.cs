using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Payroll
    {
        [Key]
        public int PayrollId { get; set; } // Primary Key
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }

        public DateTime PayDate { get; set; }
        public double BasicSalary { get; set; }
        public double OvertimeHours { get; set; }
        public double OvertimePay { get; set; }
        public double Allowances { get; set; }
        public double Bonuses { get; set; } 
        public double Deductions { get; set; }
        public double NetPay { get; set; }

        public double SSSContribution { get; set; }
        public double PagibigContribution { get; set; }
        public double PhilHealthContribution { get; set; }

        public ICollection<Benefit> Benefits { get; set; }
    }

}
