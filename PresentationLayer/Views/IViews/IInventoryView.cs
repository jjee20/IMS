namespace PresentationLayer.Views.IViews
{
    public interface IInventoryView
    {
        event EventHandler ShowBillType;
        event EventHandler ShowBill;
        event EventHandler ShowBranch;
        event EventHandler ShowCashBank;
        event EventHandler ShowCurrency;
        event EventHandler ShowCustomerType;
        event EventHandler ShowCustomer;
        event EventHandler ShowGoodsReceivedNote;
        event EventHandler ShowInvoiceType;
        event EventHandler ShowInvoice;
        event EventHandler ShowPaymentReceive;
        event EventHandler ShowPaymentType;
        event EventHandler ShowPaymentVoucher;
        event EventHandler ShowProductType;
        event EventHandler ShowProduct;
        event EventHandler ShowPurchaseOrder;
        event EventHandler ShowPurchaseType;
        event EventHandler ShowSalesOrder;
        event EventHandler ShowSalesType;
        event EventHandler ShowShipmentType;
        event EventHandler ShowShipment;
        event EventHandler ShowUnitOfMeasure;
        event EventHandler ShowVendorType;
        event EventHandler ShowVendor;
        TabPage TabControlPage { get; }
    }
}