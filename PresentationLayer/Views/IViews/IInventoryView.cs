namespace PresentationLayer.Views.IViews
{
    public interface IInventoryView
    {
        event EventHandler ShowCustomerType;
        TabPage TabControlPage { get; }
    }
}