using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace PresentationLayer.Views.UserControls
{
    public interface IDepartmentView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler EditEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;

        void SetDepartmentListBindingSource(IEnumerable<DepartmentViewModel> DepartmentList);
    }
}