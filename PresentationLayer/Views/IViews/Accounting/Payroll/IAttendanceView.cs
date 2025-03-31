using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IAttendanceView
    {
        SfDataGrid DataGrid { get; }
        int AttendanceId { get; set; }
        int EmployeeId { get; set; }
        string EmployeeName { get; set; }
        int EmployeeIdFromTextBox { get; set; }
        int ProjectId { get; set; }
        TimeSpan TimeIn { get; set; }
        TimeSpan TimeOut { get; set; }
        DateTime Date { get; set; }
        bool IsPresent { get; set; }
        bool IsHalfDay { get; set; }
        double HoursWorked { get; set; }
        bool IsEdit { get; set; }
        bool IsIndividual { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        OpenFileDialog OpenFileDialog { get; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;
        event EventHandler ShowAttendanceEvent;
        void SetAttendanceListBindingSource(BindingSource AttendanceList);
        void SetIndividualAttendanceListBindingSource(BindingSource IndividualAttendanceList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
        void SetProjectListBindingSource(BindingSource ProjectList);
        void SetEmployeeItem(Employee employee);
    }
}