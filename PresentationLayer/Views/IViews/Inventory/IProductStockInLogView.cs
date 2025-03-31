using DomainLayer.Enums;
using Syncfusion.WinForms.DataGrid;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IProductStockInLogView
    {
        SfDataGrid DataGrid { get; }
        DateTime DateAdded { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string Notes { get; set; }
        int ProductId { get; set; }
        int ProductStockInLogId { get; set; }
        string SearchValue { get; set; }
        double StockQuantity { get; set; }
        ProductStatus ProductStatus { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetProductStockInLogListBindingSource(BindingSource ProductStockInLogList);
        void SetProductListBindingSource(BindingSource bindingSource);
        void SetProductStatusListBindingSource(BindingSource bindingSource);
    }
}