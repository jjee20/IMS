using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IBillView
    {
        int BillId { get; set; }
        string BillName { get; set; }
        int GoodsReceivedNoteId { get; set; }
        string VendorDONumber { get; set; }
        string VendorInvoiceNumber { get; set; }
        DateTimeOffset BillDate { get; set; }
        DateTimeOffset BillDueDate { get; set; }
        int BillTypeId { get; set; }
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

        void SetBillListBindingSource(BindingSource BillList);
        void SetBillTypeListBindingSource(BindingSource BillTypeBindingSource);
        void SetGoodsReceivedNoteListBindingSource(BindingSource GoodsReceivedNoteBindingSource);
    }
}