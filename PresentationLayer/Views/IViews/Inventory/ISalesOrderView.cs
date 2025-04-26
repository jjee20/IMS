using DomainLayer.ViewModels.Inventory;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface ISalesOrderView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler EditEvent;
        event CellClickEventHandler PaymentEvent;
        event CellClickEventHandler InvoiceEvent;
        event CellClickEventHandler DetailsEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;

        void SetSalesOrderListBindingSource(IEnumerable<SalesOrderViewModel> SalesOrderList);
    }
}