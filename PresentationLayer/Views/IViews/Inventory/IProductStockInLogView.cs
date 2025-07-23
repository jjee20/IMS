using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IProductStockInLogView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler EditEvent;
        event CellClickEventHandler IndividualPrintEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;

        void SetProductInStockLogListBindingSource(IEnumerable<ProductStockInLogViewModel> ProductInStockLogList);
    }
}