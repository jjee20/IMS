using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IShiftView
    {
        SfDataGrid DataGrid { get; }
        int ShiftId { get; set; }
        string ShiftName { get; set; }
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        double OvertimeRate { get; set; }
        double RegularHours { get; set; }
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

        void SetShiftListBindingSource(BindingSource ShiftList);
    }
}