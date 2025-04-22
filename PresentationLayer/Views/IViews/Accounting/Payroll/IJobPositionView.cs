using DomainLayer.ViewModels.PayrollViewModels;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace PresentationLayer.Views.UserControls
{
    public interface IJobPositionView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler EditEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;

        void SetJobPositionListBindingSource(IEnumerable<JobPositionViewModel> JobPositionList);
    }
}