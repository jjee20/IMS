namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IProductInventoryView
    {
        event EventHandler ShowProductType;
        event EventHandler ShowUnitOfMeasure;
        event EventHandler ShowProduct;
        event EventHandler ShowStockIn;
        event EventHandler ShowStockMonitoring;
        TabPage Guna2TabControlPage { get; }
    }
}