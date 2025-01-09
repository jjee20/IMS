namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IConfigurationView
    {
        event EventHandler ShowUserRole;
        TabPage Guna2TabControlPage { get; }
    }
}