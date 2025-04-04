using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IWarehouseView
    {
        SfDataGrid DataGrid { get; }
        int WarehouseId { get; set; }
        string WarehouseName { get; set; }
        string Description { get; set; }
        int BranchId { get; set; }
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

        void SetWarehouseListBindingSource(BindingSource WarehouseList);
        void SetBranchListBindingSource(BindingSource BranchList);
    }
}