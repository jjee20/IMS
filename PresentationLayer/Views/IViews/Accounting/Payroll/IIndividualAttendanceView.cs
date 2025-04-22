using DomainLayer.ViewModels.PayrollViewModels;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IIndividualAttendanceView
    {
        event EventHandler? AddEvent;
        event CellClickEventHandler? DeleteEvent;
        event CellClickEventHandler? EditEvent;
        event EventHandler? MultipleDeleteEvent;
        event EventHandler? PrintEvent;
        event EventHandler? SearchEvent;

        DateTime StartDate { get; }
        DateTime EndDate { get; }
        SfDataGrid DataGrid { get; }
        void SetIndividualAttendanceList(IEnumerable<IndividualAttendanceViewModel> list);
    }
}