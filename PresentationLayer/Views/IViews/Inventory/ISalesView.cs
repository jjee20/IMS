namespace PresentationLayer.Views.IViews.Inventory
{
    public interface ISalesView
    {
        event EventHandler ShowCustomer;
        event EventHandler ShowSalesOrder;
        event EventHandler ShowShipment;
        event EventHandler ShowSalesInvoice;
        event EventHandler ShowPaymentReceive;
        event EventHandler ShowSettings;
        TabPage Guna2TabControlPage { get; }
    }
}