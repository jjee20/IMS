using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IInvoiceTypeView
    {
        int InvoiceTypeId { get; set; }
        string InvoiceTypeName { get; set; }
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;

        void SetInvoiceTypeListBindingSource(BindingSource InvoiceTypeList);
    }
}