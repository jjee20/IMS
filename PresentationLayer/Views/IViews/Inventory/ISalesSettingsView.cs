namespace PresentationLayer.Views.IViews.Inventory
{
    public interface ISettingsView
    {
        event EventHandler ShowCustomerType;
        event EventHandler ShowSalesType;
        event EventHandler ShowShipmentType;
        event EventHandler ShowInvoiceType;
        event EventHandler ShowPaymentType;
        event EventHandler ShowVendorType;
        event EventHandler ShowPurchaseType;
        event EventHandler ShowBillType;
        TabPage Guna2TabControlPage { get; }
    }
}