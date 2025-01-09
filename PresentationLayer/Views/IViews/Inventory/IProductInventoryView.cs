namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IProductInventoryView
    {
        event EventHandler ShowProductType;
        event EventHandler ShowUnitOfMeasure;
        event EventHandler ShowProduct;
        TabPage Guna2TabControlPage { get; }
    }
}