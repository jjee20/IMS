namespace PresentationLayer.Views.IViews
{
    public interface IConfigurationView
    {
        TabPage TabControlPage { get; }

        event EventHandler ShowBillType;
        event EventHandler ShowBranch;
        event EventHandler ShowCashBank;
        event EventHandler ShowCurrency;
        event EventHandler ShowInvoiceType;
        event EventHandler ShowPaymentType;
        event EventHandler ShowShipmentType;
        event EventHandler ShowWarehouse;
    }
}