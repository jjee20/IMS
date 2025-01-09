namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IInventoryView
    {
        event EventHandler ShowProfile;
        event EventHandler ShowDashboard;
        event EventHandler ShowSales;
        event EventHandler ShowPurchase;
        event EventHandler ShowInventory;
        event EventHandler ShowConfiguration;
        TabPage Guna2TabControlPage { get; }

        void ShowForm();
    }
}