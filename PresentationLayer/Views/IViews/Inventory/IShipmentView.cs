using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IShipmentView
    {
        SfDataGrid DataGrid { get; }
        int ShipmentId { get; set; }
        string ShipmentName { get; set; }
        int SalesOrderId { get; set; }
        DateTimeOffset ShipmentDate { get; set; }
        int ShipmentTypeId { get; set; }
        int WarehouseId { get; set; }
        bool IsFullShipment { get; set; }
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

        void SetShipmentListBindingSource(BindingSource ShipmentList);
        void SetShipmentTypeListBindingSource(BindingSource ShipmentTypeBindingSource);
        void SetSalesOrderListBindingSource(BindingSource OrderListBindingSource);
        void SetWarehouseListBindingSource(BindingSource WarehouseBindingSource);
    }
}