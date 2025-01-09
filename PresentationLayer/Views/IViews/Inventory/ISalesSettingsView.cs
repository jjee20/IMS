namespace PresentationLayer.Views.IViews.Inventory
{
    public interface ISalesSettingsView
    {
        event EventHandler ShowCustomerType;
        event EventHandler ShowSalesType;
        event EventHandler ShowShipmentType;
        event EventHandler ShowInvoiceType;
        TabPage Guna2TabControlPage { get; }
    }
}