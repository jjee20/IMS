namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IInventoryView
    {
        event EventHandler ShowDashboard;
        event EventHandler ShowSales;
        event EventHandler ShowPurchase;
        event EventHandler ShowInventory;
        event EventHandler ShowProject;
        event EventHandler ShowTargetGoals;
        event EventHandler ShowSalesReport;
        event EventHandler ShowPurchaseReport;
        event EventHandler ShowCustomers;
        event EventHandler ShowVendors;
        event EventHandler ShowWarehouse;
        event EventHandler ShowCashBank;
        event EventHandler ShowSettings;
        event EventHandler ShowProfile;
        TabPage Guna2TabControlPage { get; }

        void ShowForm();
    }
}