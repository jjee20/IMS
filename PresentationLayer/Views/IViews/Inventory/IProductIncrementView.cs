using DomainLayer.ViewModels.InventoryViewModels;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.Inventory;
public interface IProductIncrementView : IMessageBase
{
    void SetPermissions();
    void SetProductIncrementListBindingSource(IEnumerable<ProductIncrementViewModel> ProductIncrementList);
}