using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IProductView
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        string ProductCode { get; set; }
        string Barcode { get; set; }
        string Description { get; set; }
        string ProductImageUrl { get; set; }
        int UnitOfMeasureId { get; set; }
        double DefaultBuyingPrice { get; set; }
        double DefaultSellingPrice { get; set; }
        int BranchId { get; set; }
        int CurrencyId { get; set; }
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

        void SetProductListBindingSource(BindingSource ProductList);
        void SetProductTypeListBindingSource(BindingSource ProductTypeBindingSource);
        void SetUnitOfMeasureListBindingSource(BindingSource UnitOfMeasureBindingSource);
        void SetBranchListBindingSource(BindingSource BranchBindingSource);
        void SetCurrencyListBindingSource(BindingSource CurrencyBindingSource);
    }
}