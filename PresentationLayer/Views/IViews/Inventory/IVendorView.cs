using DomainLayer.ViewModels.Inventory;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IVendorView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler EditEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;

        void SetVendorListBindingSource(IEnumerable<VendorViewModel> VendorList);
    }
}