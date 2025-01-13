using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews.Payroll
{
    public interface IAttendanceView
    {
        int AttendanceId { get; set; }
        int EmployeeId { get; set; }
        TimeSpan TimeIn { get; set; }
        TimeSpan TimeOut { get; set; }
        DateTime Date { get; set; }
        bool IsPresent { get; set; }
        double HoursWorked { get; set; }
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

        void SetAttendanceListBindingSource(BindingSource AttendanceList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}