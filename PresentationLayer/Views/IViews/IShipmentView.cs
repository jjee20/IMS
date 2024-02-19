namespace PresentationLayer.Views.IViews
{
    public interface IShipmentView
    {
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        int ShipmentId { get; set; }
        string ShipmentName { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetShipmentListBindingSource(BindingSource ShipmentList);
    }
}