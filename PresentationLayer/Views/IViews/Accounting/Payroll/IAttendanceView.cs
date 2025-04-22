using DomainLayer.ViewModels.PayrollViewModels;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace PresentationLayer.Views.UserControls
{
    public interface IAttendanceView
    {
        SfDataGrid DataGrid { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;
        event CellClickEventHandler ShowAttendanceEvent;

        void SetAttendanceListBindingSource(IEnumerable<AttendanceViewModel> AttendanceList);
    }
}