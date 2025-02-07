namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IPurchaseView
    {
        event EventHandler ShowPurchaseOrder;
        event EventHandler ShowGoodsReceiveNote;
        event EventHandler ShowBill;
        event EventHandler ShowPaymentVoucher;
        event EventHandler ShowSettings;
        event EventHandler ShowVendor;
        TabPage Guna2TabControlPage { get; }
    }
}