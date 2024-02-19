namespace PresentationLayer.Views.IViews
{
    public interface IPurchaseTypeView
    {
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        int PurchaseTypeId { get; set; }
        string PurchaseTypeName { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetPurchaseTypeListBindingSource(BindingSource PurchaseTypeList);
    }
}