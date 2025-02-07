using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews.Payroll
{
    public interface IShiftView
    {
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