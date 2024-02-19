namespace PresentationLayer.Views.IViews
{
    public interface IWarehouseView
    {
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        int WarehouseId { get; set; }
        string WarehouseName { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetWarehouseListBindingSource(BindingSource WarehouseList);
    }
}