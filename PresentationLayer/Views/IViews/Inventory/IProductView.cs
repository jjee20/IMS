using DomainLayer.ViewModels.Inventory;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IProductView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        int ProductId { get; set; }
        string ProductName { get; set; }
        string ProductCode { get; set; }
        string Barcode { get; set; }
        string Description { get; set; }
        string Brand { get; set; }
        string PSize { get; set; }
        string PColor { get; set; }
        int UnitOfMeasureId { get; set; }
        int ProductTypeId { get; set; }
        int ReorderLevel { get; set; }
        double DefaultBuyingPrice { get; set; }
        double DefaultSellingPrice { get; set; }
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

        void SetProductListBindingSource(IEnumerable<ProductViewModel> ProductList);
        void SetProductTypeListBindingSource(BindingSource ProductTypeBindingSource);
        void SetUnitOfMeasureListBindingSource(BindingSource UnitOfMeasureBindingSource);
        void SetBranchListBindingSource(BindingSource BranchBindingSource);
    }
}