using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface ISalesOrderView
    {
        int SalesOrderId { get; set; }
        string SalesOrderName { get; set; }
        int BranchId { get; set; }
        int CustomerId { get; set; }
        DateTimeOffset OrderDate { get; set; }
        DateTimeOffset DeliveryDate { get; set; }
        string CustomerRefNumber { get; set; }
        int SalesTypeId { get; set; }
        string Remarks { get; set; }
        double Amount { get; set; }
        double SubTotal { get; set; }
        double Discount { get; set; }
        double Tax { get; set; }
        double Freight { get; set; }
        double Total { get; set; }
        List<SalesOrderLineViewModel> SalesOrderLines { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        int ProductId { get; set; }
        double ProductQuantity { get; set; }
        double ProductDiscount { get; set; }
        bool NonStock { get; set; }
        string NonStockProductName { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;
        event EventHandler ProductAddEvent;
        event EventHandler PaymentDiscountEvent;
        event EventHandler FreightEvent;
        event DataGridViewCellEventHandler PrintSOEvent;
        event DataGridViewCellEventHandler DeleteProductEvent;

        void SetSalesOrderListBindingSource(BindingSource SalesOrderList);
        void SetSalesOrderLineListBindingSource(BindingSource SalesOrderLineList);
        void SetSalesTypeListBindingSource(BindingSource SalesTypeBindingSource);
        void SetBranchListBindingSource(BindingSource BranchBindingSource);
        void SetCustomerListBindingSource(BindingSource CustomerBindingSource);
        void SetProductListBindingSource(BindingSource ProductBindingSource);
    }
}