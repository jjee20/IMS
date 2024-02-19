namespace PresentationLayer.Views.IViews
{
    public interface IPurchaseOrderView
    {
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        int PurchaseOrderId { get; set; }
        string PurchaseOrderName { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetPurchaseOrderListBindingSource(BindingSource PurchaseOrderList);
    }
}