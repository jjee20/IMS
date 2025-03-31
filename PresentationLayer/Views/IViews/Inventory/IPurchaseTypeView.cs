using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IPurchaseTypeView
    {
        SfDataGrid DataGrid { get; }
        int PurchaseTypeId { get; set; }
        string PurchaseTypeName { get; set; }
        string Description { get; set; }
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

        void SetPurchaseTypeListBindingSource(BindingSource PurchaseTypeList);
    }
}