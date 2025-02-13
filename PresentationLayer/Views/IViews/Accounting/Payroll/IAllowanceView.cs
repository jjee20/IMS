using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IAllowanceView
    {
        int AllowanceId { get; set; }
        public AllowanceType AllowanceType { get; set; }
        double Amount { get; set; }
        DateTime DateGranted { get; set; }
        string Description { get; set; }
        int EmployeeId { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        bool IsRecurring { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;

        void SetAllowanceListBindingSource(BindingSource AllowanceList);
        void SetAllowanceTypeListBindingSource(BindingSource AllowanceTypeList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}