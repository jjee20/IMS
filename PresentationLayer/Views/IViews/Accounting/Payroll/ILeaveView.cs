using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface ILeaveView
    {
        int LeaveId { get; set; }
        int EmployeeId { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
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

        void SetLeaveListBindingSource(BindingSource LeaveList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
        void SetLeaveTypeListBindingSource(BindingSource LeaveTypeList);
        void SetStatusListBindingSource(BindingSource StatusList);
    }
}