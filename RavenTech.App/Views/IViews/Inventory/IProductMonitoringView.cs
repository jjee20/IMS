namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IProductMonitoringView
    {
        double InStock { set; }
        double LowStock { set; }
        double OutOfStock { set; }

        event EventHandler PrintEvent;

        void SetInStockListBindingSource(BindingSource source);
        void SetLowStockListBindingSource(BindingSource source);
        void SetOutOfStockListBindingSource(BindingSource source);
    }
}