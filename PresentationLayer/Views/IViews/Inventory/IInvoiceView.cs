using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IInvoiceView
    {
        int InvoiceId { get; set; }
        string InvoiceName { get; set; }
        int ShipmentId { get; set; }
        DateTimeOffset InvoiceDate { get; set; }
        DateTimeOffset InvoiceDueDate { get; set; }
        int InvoiceTypeId { get; set; }
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

        void SetInvoiceListBindingSource(BindingSource InvoiceList);
        void SetInvoiceTypeListBindingSource(BindingSource InvoiceTypeList);
        void SetShipmentListBindingSource(BindingSource ShipmentList);
    }
}