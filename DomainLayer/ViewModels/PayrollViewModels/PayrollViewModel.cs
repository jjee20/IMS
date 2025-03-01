using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class PayrollViewModel
    {
        public string Employee { get; set; }
        [Display(Name = "Daily Rate")]
        public double DailyRate { get; set; }
        [Display(Name = "Days Worked")]
        public double DaysWorked { get; set; }
        [Display(Name = "Basic Salary")]
        public double BasicSalary { get; set; }
        [Display(Name = "Overtime Pay")]
        public double OvertimePay { get; set; }
        public double Allowances { get; set; }
        public double Benefits { get; set; }
        public double Bonuses { get; set; }
        [Display(Name = "Gross Pay")]
        public double GrossPay => BasicSalary + OvertimePay + Allowances + Benefits + Bonuses;
        [Display(Name = "Late/Early")]
        public double LateAndEarly { get; set; }
        public double Absent { get; set; }
        [Display(Name = "SSS")]
        public double SSSContribution { get; set; }
        [Display(Name = "Pag-ibig")]
        public double PagibigContribution { get; set; }
        [Display(Name = "PhilHealth")]
        public double PhilHealthContribution { get; set; }
        [Display(Name = "Add'l Deduction")]
        public double Deductions { get; set; }
        [Display(Name = "Total Deduction")]
        public double TotalDeduction => LateAndEarly + Absent + SSSContribution + PagibigContribution + PhilHealthContribution + Deductions;
        [Display(Name = "Net Pay")]
        public double NetPay => GrossPay - TotalDeduction;

    }

}
