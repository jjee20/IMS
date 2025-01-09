namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IPurchaseSettingsView
    {
        event EventHandler ShowPaymentType;
        event EventHandler ShowBranch;
        event EventHandler ShowCashBank;
        event EventHandler ShowVendorType;
        event EventHandler ShowPurchaseType;
        event EventHandler ShowBillType;
        TabPage Guna2TabControlPage { get; }
    }
}