using DomainLayer.Enums;
using DomainLayer.ViewModels.PayrollViewModels;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IPayrollView
    {
        public bool IsSuccessful { get; set; }
        public SfDataGrid DataGrid { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeContribution { get; }
        public bool IncludeBenefits { get; }
        public bool All { get; }
        public int ProjectId { get; }
        string Message { get; set; }
        event EventHandler PrintPayrollEvent;
        event EventHandler SearchEvent;
        event CellClickEventHandler TMonthEvent;
        event CellClickEventHandler PrintPaySlipEvent;
        void SetPayrollListBindingSource(IEnumerable<PayrollViewModel> PayrollList);
        void SetProjectListBindingSource(BindingSource ProjectList);
    }
}