using DomainLayer.Enums;
using DomainLayer.ViewModels.PayrollViewModels;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface ILeaveView
    {
        SfDataGrid DataGrid { get; }
        int LeaveId { get; set; }
        int EmployeeId { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        DateTime SearchStartDate { get; set; }
        DateTime SearchEndDate { get; set; }
        LeaveType LeaveType { get; set; }
        Status Status { get; set; }
        string Notes { get; set; }
        string Other { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;

        void SetLeaveListBindingSource(IEnumerable<LeaveViewModel> LeaveList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
        void SetLeaveTypeListBindingSource(BindingSource LeaveTypeList);
        void SetStatusListBindingSource(BindingSource StatusList);
    }
}