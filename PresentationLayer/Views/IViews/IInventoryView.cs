namespace PresentationLayer.Views.IViews
{
    public interface IInventoryView
    {
        event EventHandler ShowCustomerType;
        event EventHandler ShowCustomer;
        TabPage TabControlPage { get; }
    }
}