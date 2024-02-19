namespace PresentationLayer.Views.IViews
{
    public interface IInventoryView
    {
        TabPage TabControlPage { get; }

        event EventHandler ShowBill;
        event EventHandler ShowConfiguration;
        event EventHandler ShowCustomer;
        event EventHandler ShowCustomerType;
        event EventHandler ShowGRN;
        event EventHandler ShowInvoice;
        event EventHandler ShowPaymentReceive;
        event EventHandler ShowPaymentVoucher;
        event EventHandler ShowProduct;
        event EventHandler ShowProductType;
        event EventHandler ShowPurchaseOrder;
        event EventHandler ShowPurchaseType;
        event EventHandler ShowSalesOrder;
        event EventHandler ShowSalesType;
        event EventHandler ShowShipment;
        event EventHandler ShowUnitOfMeasure;
        event EventHandler ShowUserAndRole;
        event EventHandler ShowVendorType;
        event EventHandler ShowVendor;
    }
}