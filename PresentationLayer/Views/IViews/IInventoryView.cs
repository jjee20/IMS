namespace PresentationLayer.Views.IViews
{
    public interface IInventoryView
    {
        event EventHandler ShowCustomerType;
        event EventHandler ShowCustomer;
        event EventHandler ShowSalesType;
        TabPage TabControlPage { get; }
    }
}