using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Payroll;
public class PayrollRun
{
    [Key]
    public int PayrollRunId { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public DateTime DateProcessed { get; set; }
    public bool IsPostedToAccounting { get; set; }
    public ICollection<Payslip> Payslips { get; set; }
}
