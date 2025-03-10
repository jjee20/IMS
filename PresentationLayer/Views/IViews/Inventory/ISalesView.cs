namespace PresentationLayer.Views.IViews.Inventory
{
    public interface ISalesView
    {
        event EventHandler ShowCustomer;
        event EventHandler ShowSalesOrder;
        event EventHandler ShowShipment;
        event EventHandler ShowSettings;
        event EventHandler ShowWarehouse;
        TabPage Guna2TabControlPage { get; }
    }
}