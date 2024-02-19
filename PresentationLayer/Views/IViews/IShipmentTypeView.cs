namespace PresentationLayer.Views.IViews
{
    public interface IShipmentTypeView
    {
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        int ShipmentTypeId { get; set; }
        string ShipmentTypeName { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetShipmentTypeListBindingSource(BindingSource ShipmentTypeList);
    }
}