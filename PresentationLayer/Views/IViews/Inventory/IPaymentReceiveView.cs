using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IPaymentReceiveView
    {
        int PaymentReceiveId { get; set; }
        string PaymentReceiveName { get; set; }
        int InvoiceId { get; set; }
        DateTimeOffset PaymentDate { get; set; }
        int PaymentTypeId { get; set; }
        double PaymentAmount { get; set; }
        bool IsFullPayment { get; set; }
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

        void SetPaymentReceiveListBindingSource(BindingSource PaymentReceiveList);
        void SetInvoiceListBindingSource(BindingSource InvoiceBindingSource);
        void SetPaymentTypeListBindingSource(BindingSource PaymentTypeBindingSource);
    }
}