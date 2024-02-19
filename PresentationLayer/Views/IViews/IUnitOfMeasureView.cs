namespace PresentationLayer.Views.IViews
{
    public interface IUnitOfMeasureView
    {
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        int UnitOfMeasureId { get; set; }
        string UnitOfMeasureName { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetUnitOfMeasureListBindingSource(BindingSource UnitOfMeasureList);
    }
}