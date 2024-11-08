using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IPurchaseOrderView
    {
        int PurchaseOrderId { get; set; }
        string PurchaseOrderName { get; set; }
        int BranchId { get; set; }
        int VendorId { get; set; }
        DateTimeOffset OrderDate { get; set; }
        DateTimeOffset DeliveryDate { get; set; }
        int CurrencyId { get; set; }
        int PurchaseTypeId { get; set; }
        string Remarks { get; set; }
        double Amount { get; set; }
        double SubTotal { get; set; }
        double Discount { get; set; }
        double Tax { get; set; }
        double Freight { get; set; }
        double Total { get; set; }
        List<PurchaseOrderLine> PurchaseOrderLines { get; set; }
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

        void SetPurchaseOrderListBindingSource(BindingSource PurchaseOrderList);
        void SetPurchaseTypeListBindingSource(BindingSource PurchaseTypeBindingSource);
        void SetBranchListBindingSource(BindingSource BranchBindingSource);
        void SetVendorListBindingSource(BindingSource VendorBindingSource);
        void SetCurrencyListBindingSource(BindingSource CurrencyBindingSource);
    }
}