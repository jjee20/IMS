using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews.Payroll
{
    public interface IPayrollView
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool IncludeContribution { get; }
        public bool IncludeBenefits { get; }
        string Message { get; set; }
        event EventHandler PrintPayrollEvent;
        event DataGridViewCellEventHandler PrintPayslipEvent;
        event EventHandler SearchEvent;
        void SetPayrollListBindingSource(BindingSource PayrollList);
    }
}