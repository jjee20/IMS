using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IPaymentVoucherView
    {
        int PaymentVoucherId { get; set; }
        string PaymentVoucherName { get; set; }
        int BillId { get; set; }
        DateTimeOffset PaymentDate { get; set; }
        int PaymentTypeId { get; set; }
        double PaymentAmount { get; set; }
        int CashBankId { get; set; }
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

        void SetPaymentVoucherListBindingSource(BindingSource PaymentVoucherList);
        void SetBillListBindingSource(BindingSource BillBindingSource);
        void SetPaymentTypeListBindingSource(BindingSource PaymentTypeBindingSource);
        void SetCashBankListBindingSource(BindingSource CashBankBindingSource);
    }
}