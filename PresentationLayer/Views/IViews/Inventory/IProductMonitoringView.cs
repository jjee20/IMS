namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IProductMonitoringView
    {
        double InStock { set; }
        double LowStock { set; }
        double OutOfStock { set; }
        double ProjectFlow { set; }
        string SearchValue { get; }

        event EventHandler PrintEvent; 
        event EventHandler SearchEvent;

        void SetInStockListBindingSource(BindingSource source);
        void SetLowStockListBindingSource(BindingSource source);
        void SetOutOfStockListBindingSource(BindingSource source);
        void SetProjectFlowListBindingSource(BindingSource source);
    }
}