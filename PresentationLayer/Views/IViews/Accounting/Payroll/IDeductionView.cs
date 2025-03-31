using DomainLayer.Enums;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IDeductionView
    {
        SfDataGrid DataGrid { get; }
        int DeductionId { get; set; }
        public DeductionType DeductionType { get; set; }
        double Amount { get; set; }
        string Description { get; set; }
        DateTime DateDeducted { get; set; }
        int EmployeeId { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;

        void SetDeductionListBindingSource(BindingSource DeductionList);
        void SetDeductionTypeListBindingSource(BindingSource DeductionTypeList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}