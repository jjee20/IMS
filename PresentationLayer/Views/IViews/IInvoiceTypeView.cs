namespace PresentationLayer.Views.IViews
{
    public interface IInvoiceTypeView
    {
        string Description { get; set; }
        int InvoiceTypeId { get; set; }
        string InvoiceTypeName { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetInvoiceTypeListBindingSource(BindingSource InvoiceTypeList);
    }
}