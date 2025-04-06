using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface ISalesOrderView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
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
        int ShipmentId { get; set; }
        string ShipmentName { get; set; }
        DateTimeOffset ShipmentDate { get; set; }
        int ShipmentTypeId { get; set; }
        int WarehouseId { get; set; }
        bool IsFullShipment { get; set; }
        int ProductId { get; set; }
        double ProductQuantity { get; set; }
        double ProductDiscount { get; set; }
        bool NonStock { get; set; }
        bool NoShipment { get; set; }
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
        event EventHandler InvoiceEvent;
        event EventHandler PaymentEvent;
        event EventHandler PrintSOEvent;
        event EventHandler DeleteProductEvent; 
        event EventHandler UpdateComputationEvent;

        void SetSalesOrderListBindingSource(IEnumerable<SalesOrderViewModel> SalesOrderList);
        void SetSalesOrderLineListBindingSource(BindingSource SalesOrderLineList);
        void SetSalesTypeListBindingSource(BindingSource SalesTypeBindingSource);
        void SetBranchListBindingSource(BindingSource BranchBindingSource);
        void SetCustomerListBindingSource(BindingSource CustomerBindingSource);
        void SetProductListBindingSource(BindingSource ProductBindingSource);
        void SetShipmentTypeListBindingSource(BindingSource ShipmentTypeBindingSource);
        void SetWarehouseListBindingSource(BindingSource WarehouseBindingSource);
    }
}