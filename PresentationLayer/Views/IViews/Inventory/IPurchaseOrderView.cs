using DomainLayer.ViewModels.Inventory;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace PresentationLayer.Views.UserControls
{
    public interface IPurchaseOrderView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler VoucherEvent;
        event CellClickEventHandler EditEvent;
        event CellClickEventHandler BillEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event CellClickEventHandler GRNEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;

        void SetPurchaseOrderListBindingSource(IEnumerable<PurchaseOrderViewModel> PurchaseOrderList);
    }
}