namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IProductMonitoringView
    {
        double InStock { set; }
        double LowStock { set; }
        double OutOfStock { set; }
        double ProjectFlow { set; }

        event EventHandler PrintEvent;

        void SetInStockListBindingSource(BindingSource source);
        void SetLowStockListBindingSource(BindingSource source);
        void SetOutOfStockListBindingSource(BindingSource source);
        void SetProjectFlowListBindingSource(BindingSource source);
    }
}