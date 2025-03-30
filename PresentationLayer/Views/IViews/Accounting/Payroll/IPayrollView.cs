using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IPayrollView
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeContribution { get; }
        public bool IncludeBenefits { get; }
        public bool All { get; }
        public int ProjectId { get; }
        string Message { get; set; }
        event EventHandler PrintPayrollEvent;
        event EventHandler PrintPayslipEvent;
        event EventHandler SearchEvent; 
        event EventHandler IncludeBenefitsEvent;
        event EventHandler ProjectEvent;
        event EventHandler AllEvent;
        void SetPayrollListBindingSource(BindingSource PayrollList);
        void SetProjectListBindingSource(BindingSource ProjectList);
    }
}